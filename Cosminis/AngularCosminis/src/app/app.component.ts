import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {fader} from './services/RouterAnimations/router-animations.service';

///import { Auth0Lock } from "@auth0-lock";

//declare var Auth0Lock;


@Component({
  selector: 'app-root',
  animations: [ // <-- add your animations here
    fader,
    // slider,
    // transformer,
    // stepper
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularCosminis';

  prepareRoute(outlet : RouterOutlet)
  {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
