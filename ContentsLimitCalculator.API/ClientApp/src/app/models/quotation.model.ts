import { Item } from './item.model';
import { Category } from './category.model';
import { CategoryService } from '../services/category.service';

export class Quotation {
  categoryService: CategoryService;
  categories: Category[];
  totalValue: number;

  public constructor(categoryService: CategoryService) {
    this.categoryService = categoryService;
    this.categories = [];
    this.totalValue = 0;
  }

  setSelectedItems(items: Item[]) {
    items.forEach((item) => {
      this.addItem(item);
    });
  }

  addItem(item: Item) {
    let category: Category = this.categories.find((category) => category.id == item.categoryId);
    if (!category) {
      this.categoryService.getCategoryById(item.categoryId).subscribe(data => {
        category = new Category(data.id, data.name, data.items);
        if (!category.items) category.items = [];
        category.items.push(item);
        category.totalValue = category.totalValue + item.value;
        this.totalValue = this.totalValue + item.value;
        this.categories.push(category);
      });
    } else {
      category.items.push(item);
      category.totalValue = category.totalValue + item.value;
      this.totalValue = this.totalValue + item.value;
    }
  }

  removeItem(id: number) {
    this.categories.forEach(cat => cat.removeItemIfExists(id));
  }
}
