namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Teacher {

        public int Id {                                                         //Creates id for teacher in the database

            get;

            set;

        }

        public string TeacherName {                                             //Sets the name of the teacher in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string TeacherPhone {//previously long                           //Sets the phone number of the teacher in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string TeacherEmail {                                            //Sets the email of the teacher in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string TeacherPassword {                                         //Sets the password of the teacher in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public List<Student>? Students {                                        //Gives teacher access to the students through a many to many relationship

            get;

            set;

        }

        public List<Course>? Courses {                                          //Gives teacher access to the courses through a many to many relationship

            get;

            set;

        }

        public List<Education>? Educations {

            get;

            set;

        }

        [JsonIgnore]
        public List<School>? Schools {

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

TeacherName

TeacherPhone

TeacherEmail

TeacherPassword

 */