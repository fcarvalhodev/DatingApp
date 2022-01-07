import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  private baseUrl: string = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

  }

  get404Error() {
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    })
  }

}
