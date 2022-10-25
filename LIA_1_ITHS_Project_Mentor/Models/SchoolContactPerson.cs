namespace LIA_1_ITHS_Project_Mentor.Models {
    public class SchoolContactPerson {

        public int Id {                                                         //Creates id for schoolcontactperson in the database

            get;

            set;

        }

        public string SchoolContactPersonName {                                 //Sets the name of the schoolcontactperson in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string SchoolContactPersonEmail {                                //Sets the email of the schoolcontactperson in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string SchoolContactPersonPhone {                                //Sets the phone number of the schoolcontactperson in the database table

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

        [JsonIgnore]
        public List<Administrator>? Administrators {

            get;

            set;

        }

    }
}


/*
 
 Id

SchoolContactPersonName

SchoolContactPersonEmail

SchoolContactPersonPhone

 */
