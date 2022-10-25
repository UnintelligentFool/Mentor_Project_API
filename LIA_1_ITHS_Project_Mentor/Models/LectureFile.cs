namespace LIA_1_ITHS_Project_Mentor.Models {
    public class LectureFile {

        public int Id {                                                         //Creates id for lecturefile in the database

            get;

            set;
        
        }

        public string? FileName {                                              //Sets the name of the file in the database table

            get;

            set;
        
        }

        public DateTime LectureFileUploadedDateTime {                          //Sets the date and time the file was uploaded in the database table

            get;

            set;
        
        }

        public Lecture? Lecture {

            get;

            set;
        
        }

        public int? LectureId {

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
