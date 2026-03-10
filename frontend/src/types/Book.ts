export interface BookDto {
  id: number;
  title: string;
  author: string;
  type: string;
  category: string;
  IsLent: boolean;
  ToWhomLent: string;
}