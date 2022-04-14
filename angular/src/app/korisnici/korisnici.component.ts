import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-korisnici',
  templateUrl: './korisnici.component.html',
  styleUrls: ['./korisnici.component.css']
})
export class KorisniciComponent{

  korisniciPodac:any;
  //url = "https://localhost:44340/api";
  url = "https://seminar.p1903.app.fit.ba/api/korisnici";

  constructor(
    private http:HttpClient,
    private router:Router) {
      this.http.get(this.url).subscribe(
        podaci=>{
          this.korisniciPodac=podaci;
        }
      );
    }


  getKorisniciPodaci(){
    return this.korisniciPodac;
  }

  uredi(user:any){
    this.router.navigate(['korisnici',user.userID]);
  }
}
