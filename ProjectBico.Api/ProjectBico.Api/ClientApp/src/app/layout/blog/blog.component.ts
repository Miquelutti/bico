import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})

export class BlogComponent implements OnInit {

  text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

  constructor() { }


  ngOnInit() {
  }

  goToLink(url: string){
    window.open(url, "_blank");
  }
}
