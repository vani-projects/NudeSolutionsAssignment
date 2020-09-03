import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { ItemService } from '../services/item.service';
import { Category } from '../models/category.model';
import { Item } from '../models/item.model';
import { Quotation } from '../models/quotation.model';


@Component({
  selector: 'app-quotation',
  templateUrl: './quotation.component.html',
  styleUrls: ['./quotation.component.scss']
})
export class QuotationComponent implements OnInit {

  quotation: Quotation;
  availableCategories: Category[];
  newItem: Item = new Item();

  constructor(private itemService: ItemService,
    private categoryService: CategoryService) {
  }

  ngOnInit() {
    this.quotation = new Quotation(this.categoryService);

    this.getItemsByCategories();

    this.categoryService.getCategories().subscribe(data => {
      this.availableCategories = [];
      data.forEach((category) => {
        this.availableCategories.push(new Category(category.id, category.name, category.items));
      })
    })
  }

  DeleteItem(id) {
    this.itemService.DeleteItem(id).subscribe(() => {
      this.getItemsByCategories();
    });   
  }

  addNewItem() {
    this.itemService.postItem(this.newItem).subscribe((item) => {
      this.getItemsByCategories();
      this.newItem = new Item();
    });
  }

  stripCurrency(amount: string): string {
    if (amount.indexOf("$") > 0) {
      return amount.substr(3).replace(/,/g,'');
    } else {
      return amount.replace(/,/g, '');
    }
  }

  getItemsByCategories() {
    this.quotation.categories = [];
    this.quotation.totalValue = 0;
    this.categoryService.getCategories().subscribe((categories) => {
      categories.forEach(category => {
        let newCategory = new Category(category.id, category.name, category.items);
        if (newCategory.items && newCategory.items.length > 0)
          this.quotation.categories.push(newCategory);
        this.quotation.totalValue = this.quotation.totalValue + newCategory.totalValue;
      });
    });
  }
}
