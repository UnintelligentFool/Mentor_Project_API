namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public StudentController(DataContext dataContext) {                             //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetStudent/{id}")]                                                   //Creates GET for the /GetStudent route for the purpose of getting back the student with the matching id
        public async Task<ActionResult<Student>> GetStudent(int id) {                   //Takes in id in the database of the student to GET and send back

            var returnThisStudent = await dataContext.Students.FindAsync(id);           //Defines a variable for the student in the database so we can get it

            if (returnThisStudent is null) {                                            //if there is no student with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisStudent);                                               //Sends back the student that was requested

        }

        [HttpGet("/GetAllStudents/{educationId}")]                                      //Creates a GET for the /GetAllStudents route to send back a list of all students for specified education id
        public async Task<ActionResult<List<Education>>> GetAllStudents(int educationId) { //Creates method for returning list of students for specified education

            List<Education> returnTheseStudents = await dataContext.Educations.Where(edu => edu.Id == educationId).Include(students => students.Students).ToListAsync(); //Creates a List variable of type Education that contains a list of all students for the specified education id in the database

            if (returnTheseStudents is null) {                                          //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseStudents);                                             //Sends back a list with all students for the specified education from the database

        }

        [HttpGet("/GetStudentsAtSchool/{schoolId}")]                                    //Creates a GET for the /GetStudentsAtSchool route to send back a list of all students for specified school id
        public async Task<ActionResult<List<School>>> GetStudentsAtSchool(int schoolId) { //Creates method for returning list of students at specified school

            List<School> returnTheseStudents = await dataContext.Schools.Where(school => school.Id == schoolId).Include(students => students.Students).ToListAsync();//Creates a List variable of type Student that contains a list of all students for the specified school id in the database

            if (returnTheseStudents is null) {                                          //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseStudents);                                             //Sends back a list with all students for the specified school from the database

        }

        [HttpPost("/AddStudents")]                                                      //Creates POST for route /AddStudents to be able to add a list of student entries to the database
        public async Task<ActionResult<List<Student>>> AddStudents(List<Student> newStudent) { //Creates method that takes in a variable of type List<Student> for adding a list of student entries to the database

            if (newStudent is null) {                                                   //If the received value of the student list to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            foreach (Student student in newStudent) {                                   //Goes through each student in the list of students received and executes the code below

                dataContext.Students.Add(student);                                      //Adds students to the DataContext

            }

            await dataContext.SaveChangesAsync();                                       //Saves the list of students as entries in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the list of students was successful
            //return Ok(await dataContext.Students.ToListAsync());

        }

        [HttpPatch("/UpdateStudent")]                                                   //Creates PATCH for route /UpdateStudent to be used to send in new values to update a student entry in the database
        public async Task<IActionResult> UpdateStudent(int studentId, [FromBody] JsonPatchDocument<Student> newStudentValues) { // Creates method that takes in the id of the student to PATCH and the values to use for the PATCH

            var updateThisStudent = dataContext.Students.Find(studentId);               //Finds student to patch in the database and puts into a variable

            if (newStudentValues is null || updateThisStudent is null) {                //If there is no student to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newStudentValues.ApplyTo(updateThisStudent);                                //Changes the values for the student in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the student entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisStudent);

        }

        [HttpDelete("/DeleteStudent/{studentId}")]                                      //Creates DELETE for route /DeleteStudent that takes in id for student to delete from the database
        public async Task<ActionResult<List<Student>>> DeleteStudent(int studentId) {   //Creates method to delete the student in the database with the received id

            var deleteThisStudent = dataContext.Students.Find(studentId);               //Creates a variable that finds the specified student in the database

            if (deleteThisStudent is null) {                                            //If there is no student available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Students.Remove(deleteThisStudent);                             //Removes the student from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the student to the database (removes it)

            return Ok(200);                                                             //Return status code 200 to confirm successful removal of student
            //return Ok(dataContext.Students.ToListAsync());

        }

    }
}
