import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HttpClient} from '@angular/common/http';
@Component({selector:'app-root',standalone:true,imports:[CommonModule],templateUrl:'./app.component.html'})
export class AppComponent{
 incidents:any[]=[]; loading=false;
 constructor(private http:HttpClient){this.load();}
 load(){this.http.get<any[]>('http://localhost:8080/api/incidents').subscribe(x=>this.incidents=x);}
 simulate(){this.loading=true;this.http.post('http://localhost:8080/api/incidents/simulate',{}).subscribe(()=>{this.loading=false;this.load();});}
 lines(v:string){return v?.split('\n')||[];}
}
