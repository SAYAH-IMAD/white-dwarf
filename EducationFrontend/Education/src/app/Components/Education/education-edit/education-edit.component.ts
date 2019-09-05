import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import {MatDatepicker} from '@angular/material/datepicker';
import { EducationService } from 'src/app/Services/Education/education.service';
import { Education } from 'src/app/Models/Education';
import { ActivatedRoute } from '@angular/router';
import { LevelMock } from 'src/app/Mocks/Education/LevelMock';

@Component({
  selector: 'app-education-edit',
  templateUrl: './education-edit.component.html',
  styleUrls: ['./education-edit.component.css']
})
export class EducationEditComponent implements OnInit {

  education: Education = new Education();

  educations: Education[] = [];

  educationId: number;

  levels: string[] = LevelMock;


  constructor(private educationService: EducationService, private route: ActivatedRoute) { }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.educationService.getEducation(1, params.id).subscribe((item: Education) => {
        if ( item == null ) {
           this.education = new Education();
        } else {
        this.education = item;        }

      });
    });
  }

  public AddEducation() {
    this.educationService.addEducation(this.education);
  }
  public UpdateEducation() {
    this.educationService.updateEducation(this.education.id, this.education);
  }

  compareFn(x: Education, y: Education): boolean {
    return x && y ? x.id === y.id : x === y;
    }
}
