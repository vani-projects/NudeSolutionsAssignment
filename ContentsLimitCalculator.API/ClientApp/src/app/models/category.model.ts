import { Item } from './item.model';

export class Category {
  id: number;
  name: string;
  items: Item[];
  totalValue: number;

  constructor(id: number, name: string, items: Item[]) {
    this.id = id;
    this.name = name;
    this.items = items;
    this.totalValue = 0;
    if (items != null && items != undefined) {
      this.items.forEach((item) => {
        this.totalValue = this.totalValue + item.value;
      })
    }
  }

  removeItemIfExists(id: number) {
    let index = this.items.findIndex((item) => item.id == id);
    this.items.splice(index, 1);
  }
}
