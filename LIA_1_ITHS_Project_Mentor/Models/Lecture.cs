namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Lecture {

        public int Id {                                                         //Creates id for lecture in the database

            get;

            set;

        }

        public string LectureName {                                             //Sets the name of the lecture in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string? LectureDescription {                                     //Sets the lecture description of the lecture in the database table

            get;

            set;
        
        }

        public string? LectureCreatedBy {                                       //Sets the name of the person that created the lecture in the database table

            get;

            set;
        
        }

        public DateTime LectureCreatedDateTime {                                //Sets the date and time the lecture was created in the database table

            get;

            set;

        }

        public List<LectureFile>? LectureFiles {

            get;

            set;
        
        }

        public Course? Course {

            get;

            set;

        }

        public int? CourseId {

            get;

            set;

        }

        public Student? Student {

            get;

            set;

        }

        public int? StudentId {

            get;

            set;

        }

        [JsonIgnore]
        public List<Teacher>? Teachers {

            get;

            set;

        }

        [JsonIgnore]
        public List<Administrator>? Administrators {

            get;

            set;

        }

    }

}
