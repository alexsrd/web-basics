import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Dog } from './dog';
import { DogService } from './dog.service';

@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(private service: DogService,
    private router: Router) { }

  dogs: Dog[];

  ngOnInit() {
    this.service.get().subscribe(data => {
      this.dogs = data;
    });
  }

  formModel = {
    name: '',
    age: '',
    breed:''
  }

  onSubmit() {
    this.service.create(this.formModel).subscribe(
      (res: any) => this.ngOnInit(),
      err => {}
    )
  }

}
