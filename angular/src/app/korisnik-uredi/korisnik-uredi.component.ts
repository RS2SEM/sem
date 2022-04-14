import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-korisnik-uredi',
  templateUrl: './korisnik-uredi.component.html',
  styleUrls: ['./korisnik-uredi.component.css']
})
export class KorisnikUrediComponent {

  //url = "https://localhost:44340/api/korisnici/";
  url = "https://seminar.p1903.app.fit.ba/api/korisnici/";
  id:any;
  korisnik:any;

  constructor(
    private http:HttpClient,
    private _Activatedroute:ActivatedRoute,
    private router:Router) {
      this._Activatedroute.paramMap.subscribe(params => {
        this.id = params.get('id');
        this.getPodaci();
      });
    }

  getPodaci(){
    this.http.get(this.url+this.id).subscribe(
      podaci=>
      this.korisnik=podaci
    );
  }

  spremi(){
    this.http.post(this.url+this.korisnik.userID,this.korisnik).subscribe(
        podaci=>
        console.log(podaci)
    );

    this.router.navigate(['korisnici']);
  }
}
