import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Users } from '../../Models/User';
import { ResourceApiServicesService } from '../Resource-Api-Service/resource-api-service.service';
import { ComsinisApiServiceService } from '../Comsini-api-service/comsinis-api-service.service';
import { FoodElement } from '../../Models/FoodInventory';

@Injectable({
  providedIn: 'root'
})
export class UserApiServicesService {
  url : string = environment.api;

  constructor(private http: HttpClient, private resourceApi:ResourceApiServicesService, private comsiniApi:ComsinisApiServiceService) { }

  LoginOrReggi(User : Users) : Observable<Users> {
    return this.http.post(this.url + `Users/LoggiORReggi`, User) as Observable<Users>;
  } 

  Find(ID : number) : Observable<Users> {
    return this.http.get(this.url + `Users/Find?user2Check=${ID}`) as Observable<Users>;
  } 

  searchFriend(username : string) : Observable<Users> {
    return this.http.get(this.url + `searchFriend?username=${username}`) as Observable<Users>;
  } 

  UpdateNavBar() : void
  {
    let stringUser : string   = sessionStorage.getItem('currentUser') as string; 
    let currentUser : Users = JSON.parse(stringUser);
    let foodDisplay : FoodElement[] = []
    
    this.LoginOrReggi(currentUser).subscribe((res) => //updates gem, gold and egg
    {
      currentUser = res;
      window.sessionStorage.setItem('currentUser', JSON.stringify(currentUser));
    })

    this.resourceApi.CheckFood(currentUser.userId as number).subscribe((res) => //updates food
    {
      foodDisplay= res;
      if(foodDisplay.length>0)
      {
        window.sessionStorage.setItem('SpicyFoodCount', foodDisplay[0].foodCount as unknown as string);
        window.sessionStorage.setItem('ColdFoodCount', foodDisplay[1].foodCount as unknown as string);
        window.sessionStorage.setItem('LeafyFoodCount', foodDisplay[2].foodCount as unknown as string);
        window.sessionStorage.setItem('FluffyFoodCount', foodDisplay[3].foodCount as unknown as string);
        window.sessionStorage.setItem('BlessedFoodCount', foodDisplay[4].foodCount as unknown as string);
        window.sessionStorage.setItem('CursedFoodCount', foodDisplay[5].foodCount as unknown as string);
      }
      else
      {
        window.sessionStorage.setItem('SpicyFoodCount', '0');
        window.sessionStorage.setItem('ColdFoodCount', '0');
        window.sessionStorage.setItem('LeafyFoodCount', '0');
        window.sessionStorage.setItem('FluffyFoodCount', '0');
        window.sessionStorage.setItem('BlessedFoodCount', '0');
        window.sessionStorage.setItem('CursedFoodCount', '0');
      }
    });

    this.comsiniApi.getCosminiByID(currentUser.showcaseCompanionFk as number).subscribe((res) =>
    {
    })
  }
}
