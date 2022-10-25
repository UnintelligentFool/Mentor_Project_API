namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Student {

        public int Id {                                                         //Creates id for student in the database

            get;

            set;

        }

        public string StudentName {                                             //Sets the name of the student in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string StudentEmail {                                            //Sets the email of the student in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string StudentPassword {                                         //Sets the password of the student in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        [JsonIgnore]
        public List<Education>? Educations {

            get;

            set;

        }

        public List<Course>? Courses {

            get;

            set;

        }

        public List<Lecture>? Lectures {

            get;

            set;

        }

        [JsonIgnore]
        public List<School>? Schools {

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

StudentName

StudentEmail

StudentPassword

 */