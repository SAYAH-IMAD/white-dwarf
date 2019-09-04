import { Component, OnInit, Input } from '@angular/core';
import { Education } from 'src/app/Models/Education';

@Component({
  selector: 'app-education-details',
  templateUrl: './education-details.component.html',
  styleUrls: ['./education-details.component.css']
})
export class EducationDetailsComponent implements OnInit {

  @Input()
  education: Education;

  constructor() { }

  ngOnInit() {
  }
}
