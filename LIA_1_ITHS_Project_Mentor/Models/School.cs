namespace LIA_1_ITHS_Project_Mentor.Models {
    public class School {

        public int Id {                                                         //Creates id for school in the database

            get;

            set;

        }

        public string SchoolName {                                              //Sets the name of the school in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public string SchoolEmail {                                             //Sets the email of the school in the database table

            get;

            set;

        } = string.Empty;                                                       //Sets the value to empty as default value

        public long SchoolOrganisationNumber {                                  //Sets the organisation number of the school in the database table

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

        public List<Teacher>? Teachers {

            get;

            set;

        }

        public List<Student>? Students {

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

SchoolName

SchoolEmail

SchoolOrganisationNumber

 */