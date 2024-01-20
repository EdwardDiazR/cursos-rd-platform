import { Component, Input, OnInit } from '@angular/core';
import { Teacher } from 'src/app/Models/teacher';

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css'],
})
export class ProfileImageComponent implements OnInit{

  @Input() Image!: File;
  @Input() teacher!:Teacher

  
  ngOnInit(): void {
  }


}
