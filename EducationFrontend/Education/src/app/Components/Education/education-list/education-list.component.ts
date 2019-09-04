import { Component, OnInit, Input } from '@angular/core';
import { Education } from 'src/app/Models/Education';
import { EducationService } from 'src/app/Services/Education/education.service';

@Component({
  selector: 'app-education-list',
  templateUrl: './education-list.component.html',
  styleUrls: ['./education-list.component.css']
})
export class EducationListComponent implements OnInit {

  educations: Education[] = [];
  selectedEducation: Education;
  constructor(private education: EducationService) { }

  ngOnInit() {
    this.education.getEducations(1).subscribe(e  => {
      this.educations = e;
    });
  }

}
