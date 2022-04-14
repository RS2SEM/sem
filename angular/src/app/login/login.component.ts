import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username:string="";
  password:string="";

  constructor(private http: HttpClient,private router:Router) { }

  ngOnInit(): void {
  }

  login(){
    var url = "https://seminar.p1903.app.fit.ba";
    const  headers = { 'Content-Type':'application/json'}

    //this.http.post(url + '/Prijava/PrijavaAngular' + '?username=' + this.username + '&lozinka=' + this.password, { 'headers': headers }).subscribe();
    this.router.navigate(['korisnici']);
  }
}
