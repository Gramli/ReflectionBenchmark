import "dotenv/config";
import {
  GoogleGenAI,
  type Content,
  type GenerateContentConfig,
  type GenerateContentResponse,
} from "@google/genai";

export type GenerateRequest = {
  contents: Content[];
  config?: GenerateContentConfig;
};

export class GenaiService {
  private readonly ai: GoogleGenAI;
  private readonly model: string;

  constructor(model: string = "gemini-3.5-flash") {
    this.model = model;
    const apiKey = process.env.GEMINI_API_KEY;
    if (!apiKey) {
      throw new Error("Missing GEMINI_API_KEY in .env");
    }

    this.ai = new GoogleGenAI({ apiKey });
  }

  public async generateContentAsync(
    request: GenerateRequest,
  ): Promise<GenerateContentResponse> {
    const response = await this.ai.models.generateContent({
      model: this.model,
      contents: request.contents,
      config: request.config,
    });

    return response;
  }
}
