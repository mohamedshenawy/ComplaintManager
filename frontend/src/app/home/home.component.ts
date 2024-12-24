import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { VisitService } from '../visit.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [FormsModule ,CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  phoneNumber :string  = ''
  visitList:any = [];
  customerobj:any = null;
  constructor(private visitService:VisitService){}
  searchByPhoneNumber(){
  this.visitService.searchVisitByCustomerPhoneNumber(this.phoneNumber).subscribe((res)=>{
    console.log(res);
    
    this.customerobj = res.customer;
    this.visitList = res.visits;


  })
}

}
