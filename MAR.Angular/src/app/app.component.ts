import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IRequest} from './irequest';
import {RequestMethod} from './request-method.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  request: IRequest[];
  personData: any;
  cityData: any;
  constructor(private http: HttpClient){
      this.request = [];
      this.request.push({
        name: 'personData',
        resource: 'person',
        method: RequestMethod.GET,
        data : [],
      });
    this.request.push({
      name: 'cityData',
      resource: 'city',
      method: RequestMethod.GET,
      data : [],
    });
    this.http.post('http://localhost:5000/api/request', this.request).subscribe(res => {
        this.personData = res['personData'];
      this.cityData = res['cityData'];
    });
  }


}
