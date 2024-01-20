import { Teacher } from './teacher';

interface Course {
  id: string;
  name: string;
  description:string;
  price: number;
  publishedDate: Date;
  teacher: Teacher;
  isPublic: boolean;
  urlTitle:string
}

interface CourseDto {
  Name: string;
  Description: string;
  Price: number;
  PublishedDate: Date;
  Language: string;
  TeacherId: number;
  TitleKeywords: string[]
}

export { Course, CourseDto };
