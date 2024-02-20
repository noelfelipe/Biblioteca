import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../service/httpProvider/http-provider.service';

@Component({
  selector: 'app-edit-book',
  templateUrl: './book-update.component.html',
  styleUrls: ['./book-update.component.scss']
})
export class EditBookComponent implements OnInit {
  editBookForm: BookForm = new BookForm();

  @ViewChild("bookForm")
  bookForm!: NgForm;

  isSubmitted: boolean = false;
  bookId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.bookId = this.route.snapshot.params['bookId'];
    this.getBookDetailById();
  }

  getBookDetailById() {
    this.httpProvider.getBookDetailById(this.bookId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.editBookForm.Id = resultData.id;
          this.editBookForm.Titulo = resultData.titulo;
          this.editBookForm.Autor = resultData.autor;
          this.editBookForm.DataPublicacao = resultData.dataPublicacao;
          this.editBookForm.ISBN = resultData.isbn;
        }
      }
    },
      (error: any) => { });
  }

  EditBook(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.updateBook(this.editBookForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
          if (resultData != null && resultData.isSuccess) {
            this.toastr.success(resultData.message);
            setTimeout(() => {
              this.router.navigate(['/Home']);
            }, 500);
          }
        }
      },
      async error => {
        setTimeout(() => {
          this.router.navigate(['/Home']);
        });
      });
    }
  }
}

export class BookForm {
  Id: number = 0;
  Titulo: string = "";
  Autor: string = "";
  DataPublicacao: string = "";
  ISBN: string = "";
}
