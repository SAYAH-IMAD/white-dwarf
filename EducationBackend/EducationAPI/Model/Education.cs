using System;
using System.Collections.Generic;
using System.Text;

namespace EducationAPI.Model
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string FieldOfStudy { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool Current { get; set; }
        public string EducationType { get; set; }
    }
}
