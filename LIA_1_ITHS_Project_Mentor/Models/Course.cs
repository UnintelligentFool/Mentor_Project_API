namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Course {

        public int Id {                                                         //Creates id for course in the database

            get;

            set;
        
        }

        public string CourseName {                                              //Sets the name of the course in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public Education? Education {

            get;

            set;
        
        }

        public int? EducationId {

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

        //public Teacher Teacher {

        //    get;

        //    set;

        //}

        //public int TeacherId {

        //    get;

        //    set;

        //}

        [JsonIgnore]
        public List<Teacher>? Teachers {

            get;

            set;

        }

        public List<Lecture>? Lectures {

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


/*
 
 Id

CourseName

 */