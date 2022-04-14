import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { KorisniciComponent } from './korisnici/korisnici.component';
import { KorisnikUrediComponent } from './korisnik-uredi/korisnik-uredi.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent,
},
  {
      path: 'Login', component: LoginComponent,
  },
  {
      path:'Registracija',component:RegisterComponent
  },
  {
    path:'korisnici',component:KorisniciComponent
  },
  {
    path:'korisnici/:id',component:KorisnikUrediComponent
  },
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    KorisniciComponent,
    KorisnikUrediComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


