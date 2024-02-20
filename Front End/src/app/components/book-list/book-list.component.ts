import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpProviderService } from '../../service/httpProvider/http-provider.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class ListBookComponent implements OnInit {

  bookId: any;
  bookDetail: any = [];

  constructor(private route: ActivatedRoute, private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.bookId = this.route.snapshot.params['bookId'];
    this.getBookDetailById();
  }

  getBookDetailById() {
    this.httpProvider.getBookDetailById(this.bookId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.bookDetail = resultData;
        }
      }
    },
      (error: any) => { });
  }
}
