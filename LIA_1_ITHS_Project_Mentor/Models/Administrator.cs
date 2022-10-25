namespace LIA_1_ITHS_Project_Mentor.Models {
    public class Administrator {

        public int Id {                                                         //Creates id for administrator in the database

            get;

            set;

        }

        public string AdministratorName {                                       //Sets the name of the administrator in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string AdministratorEmail {                                      //Sets the email of the administrator in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string AdministratorPassword {                                   //Sets the password of the administrator in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string AdministratorPhone {                                      //Sets the phone number of the administrator in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public AdminCreator? AdminCreator {

            get;

            set;

        }

        public int? AdminCreatorId {

            get;

            set;

        }

        public List<School>? Schools {

            get;

            set;

        }

        public List<SchoolContactPerson>? SchoolContactPersons {

            get;

            set;

        }

        public List<Education>? Educations {

            get;

            set;

        }

        public List<Course>? Courses {

            get;

            set;

        }

        public List<Student>? Students {

            get;

            set;

        }

        public List<Teacher>? Teachers {

            get;

            set;

        }

        public List<Lecture>? Lectures {

            get;

            set;

        }

        public List<LectureFile>? LectureFiles {

            get;

            set;

        }

    }

}


/*
 
 Id

AdministratorName

AdministratorEmail

AdministratorPassword

AdministratorPhone

 */