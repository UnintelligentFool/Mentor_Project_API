namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Education {

        public int Id {                                                         //Creates id for education in the database

            get;

            set;

        }

        public string EducationName {                                           //Sets the name of the education in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public School? School {

            get;

            set;

        }

        public int SchoolId {

            get;

            set;

        }

        public List<Course>? Courses {

            get;

            set;
        
        }

        //public Student? Student {

        //    get;

        //    set;

        //}

        //public int? StudentId {

        //    get;

        //    set;

        //}

        //public Teacher Teacher {

        //    get;

        //    set;

        //}

        //public int TeacherId {

        //    get;

        //    set;

        //}

        public List<Student>? Students {

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


/*
 
 Id

EducationName

 */