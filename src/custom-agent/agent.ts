import { chromium, type Page } from "playwright";
import { GenaiService } from "./genai.service";
import {
  FunctionCallingConfigMode,
  type Content,
  type Tool,
} from "@google/genai";

export const tools: Tool[] = [
  {
    functionDeclarations: [
      {
        name: "getGameState",
        description:
          "Get the current board. visibleMap rows run top-to-bottom; each character is x=0 onward. P=player, .=land, W=tree, ~=water, B=bridge, R=rock, and G=goal.",
        responseJsonSchema: {
          type: "object",
          properties: {
            remainingMoves: { type: "number" },
            wood: { type: "number" },
            visibleMap: {
              type: "array",
              items: { type: "string" },
            },
          },
          required: ["remainingMoves", "wood", "visibleMap"],
        },
      },
    ],
  },
];

const gameUrl = process.argv[2] ?? "https://tower-before-dusk.gramli.workers.dev";

async function main() {
  const aiService = new GenaiService();
  const context = await chromium.launchPersistentContext(
    "./.chrome-agent-profile",
    {
      channel: "chrome",
      headless: false,
      args: ["--enable-experimental-web-platform-features"],
    },
  );

  const page = await context.newPage();
  await page.goto(gameUrl, { waitUntil: "networkidle" });

  const contents: Content[] = [
    {
      role: "user",
      parts: [
        {
          text: "Inspect the current Tower Before Dusk game state.",
        },
      ],
    },
  ];

  const response = await aiService.generateContentAsync({
    contents,
    config: {
      tools,
      toolConfig: {
        functionCallingConfig: {
          mode: FunctionCallingConfigMode.ANY,
          allowedFunctionNames: ["getGameState"],
        },
      },
    },
  });

  const functionCall = response.functionCalls?.[0];
  if (!functionCall?.name) {
    throw new Error("Gemini did not return a tool call");
  }
  if (functionCall.name !== "getGameState") {
    throw new Error(`Gemini requested an unknown tool: ${functionCall.name}`);
  }

  console.log("Gemini tool call:", functionCall);

  const gameState = await executeWebMcpTool(
    page,
    functionCall.name,
    functionCall.args ?? {},
  );

  console.log("Tool result:", gameState);
}

main().catch((error) => {
  console.error(error);
  process.exitCode = 1;
});

export async function executeWebMcpTool<T>(
  page: Page,
  toolName: string,
  args: unknown,
): Promise<T> {
  return await page.evaluate(
    async ({ toolName, args }) => {
      const modelContext =
        (document as any).modelContext ?? (navigator as any).modelContext;
      if (!modelContext) {
        throw new Error("Model Context API is not available");
      }

      const tools = await modelContext.getTools();

      const tool = tools.find((tool: any) => tool.name === toolName);

      if (!tool) {
        throw new Error(`Tool not found: ${toolName}`);
      }

      const result = await modelContext.executeTool(tool, JSON.stringify(args));

      return result;
    },
    { toolName, args },
  );
}
