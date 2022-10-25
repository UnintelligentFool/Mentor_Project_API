namespace LIA_1_ITHS_Project_Mentor.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        
            
        
        }

        public DbSet<AdminCreator> AdminCreators { //Create DbSet for AdminCreator class, naming table in database

            get;
            
            set;

        }

        public DbSet<Administrator> Administrators { //Create DbSet for Administrator class, naming table in database

            get;

            set;

        }

        public DbSet<Course> Courses { //Create DbSet for Course class, naming table in database

            get;

            set;

        }

        public DbSet<Education> Educations { //Create DbSet for Education class, naming table in database

            get;

            set;

        }

        public DbSet<Lecture> Lectures { //Create DbSet for Lecture class, naming table in database

            get;

            set;

        }

        public DbSet<LectureFile> LectureFiles { //Create DbSet for LectureFile class, naming table in database

            get;

            set;

        }

        public DbSet<School> Schools { //Create DbSet for School class, naming table in database

            get;

            set;

        }

        public DbSet<SchoolContactPerson> SchoolContactPersons { //Create DbSet for SchoolContactPerson class, naming table in database

            get;

            set;

        }

        public DbSet<Student> Students { //Create DbSet for Student class, naming table in database

            get;

            set;

        }

        public DbSet<Teacher> Teachers { //Create DbSet for Teacher class, naming table in database

            get;

            set;

        }

    }

}
