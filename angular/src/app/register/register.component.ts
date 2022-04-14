import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  ime:string="";
  prezime:string="";
  username:string="";
  password:string="";


  constructor(private http: HttpClient,private router:Router) {

  }
  ngOnInit(): void {
  }

  registracija(){
    var url = "https://seminar.p1903.app.fit.ba";
    const  headers = { 'Content-Type':'application/json'}

    this.http.post(url + '/Prijava/Registracija' + '?ime=' + this.ime + '&prezime=' + this.prezime + '&username=' + this.username + '&lozinka=' + this.password, { 'headers': headers }).subscribe();
    this.router.navigate(['/Login']);
  }
}
