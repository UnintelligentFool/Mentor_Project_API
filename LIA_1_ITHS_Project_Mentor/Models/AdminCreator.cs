namespace LIA_1_ITHS_Project_Mentor.Models {
    public class AdminCreator {

        public int Id {                                                         //Creates id for admincreator in the database

            get;

            set;

        }

        public string AdminCreatorEmail {                                       //Sets the email of the admincreator in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string AdminCreatorPassword {                                    //Sets the password of the admincreator in the database table

            get;
    
            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public List<Administrator>? Administrators {

            get;

            set;

        }

    }
}
