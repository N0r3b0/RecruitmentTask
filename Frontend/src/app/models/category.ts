import { SubCategory } from './subcategory';

export interface Category {
  id: number;
  name: string;
  subCategories: SubCategory[];
}
