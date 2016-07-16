import { Component } from '@angular/core';

export class Blog {
  id: number;
  name: string;
}

const BLOGS: Blog[] = [
  { id: 1, name: 'о собаках' },
  { id: 2, name: 'о кошках' },
  { id: 3, name: 'пицца' },
  { id: 4, name: 'истории' }
];

@Component({
  selector: 'my-app',
  templateUrl: 'app/app.component.html',
  
})
export class AppComponent {
  title = 'БЛОГИ';
  blogs = BLOGS;

  onSelect() {
  	console.log("iluoioi");
  }
  
}

