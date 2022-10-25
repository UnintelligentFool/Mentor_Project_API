namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public TeacherController(DataContext dataContext) {                             //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetTeacher/{id}")]                                                   //Creates GET for the /GetTeacher route for the purpose of getting back the teacher with the matching id
        public async Task<ActionResult<Teacher>> GetTeacher(int id) {                   //Takes in id in the database of the teacher to GET and send back

            var returnThisTeacher = await dataContext.Teachers.FindAsync(id);           //Defines a variable for the teacher in the database so we can get it

            if (returnThisTeacher is null) {                                            //if there is no teacher with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisTeacher);                                               //Sends back the teacher that was requested

        }

        [HttpGet("/GetTeachersAtSchool/{schoolId}")]                                    //Creates a GET for the /GetTeachersAtSchool route to send back a list of all teachers for specified school id
        public async Task<ActionResult<List<School>>> GetTeachersAtSchool(int schoolId) { //Creates method for returning list of teachers for school

            List<School> returnTheseTeachers = await dataContext.Schools.Where(source => source.Id == schoolId).Include(source => source.Teachers).ToListAsync();//Creates a List variable of type School that contains a list of all teachers for the specified school id in the database

            if (returnTheseTeachers is null) {                                          //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseTeachers);                                             //Sends back a list with all teachers for the specified school from the database

        }

        [HttpPost("/AddTeachers")]                                                      //Creates POST for route /AddTeachers to be able to add a list of teacher entries to the database
        public async Task<ActionResult<List<Teacher>>> AddTeachers(List<Teacher> newTeachers) { //Creates method that takes in a variable of type List<Teacher> for adding a list of teacher entries to the database

            if (newTeachers is null) {                                                  //If the received value of the teacher list to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            foreach (Teacher teacher in newTeachers) {                                  //Goes through each teacher in the list of teachers received and executes the code below

                dataContext.Teachers.Add(teacher);                                      //Adds teachers to the DataContext

            }

            await dataContext.SaveChangesAsync();                                       //Saves the list of teachers as entries in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the list of teachers was successful
            //return Ok(await dataContext.Teachers.ToListAsync());

        }

        [HttpPatch("/UpdateTeacher")]                                                   //Creates PATCH for route /UpdateTeacher to be used to send in new values to update a teacher entry in the database
        public async Task<IActionResult> UpdateTeacher(int teacherId, [FromBody] JsonPatchDocument<Teacher> newTeacherValues) { // Creates method that takes in the id of the teacher to PATCH and the values to use for the PATCH

            var updateThisTeacher = dataContext.Teachers.Find(teacherId);               //Finds teacher to patch in the database and puts into a variable

            if (newTeacherValues is null || updateThisTeacher is null) {                //If there is no teacher to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newTeacherValues.ApplyTo(updateThisTeacher);                                //Changes the values for the teacher in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the teacher entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisTeacher);

        }

        [HttpDelete("/DeleteTeacher/{teacherId}")]                                      //Creates DELETE for route /DeleteTeacher that takes in id for teacher to delete from the database
        public async Task<ActionResult<List<Teacher>>> DeleteTeacher(int teacherId) {   //Creates method to delete the teacher in the database with the received id

            var deleteThisTeacher = dataContext.Teachers.Find(teacherId);               //Creates a variable that finds the specified teacher in the database

            if (deleteThisTeacher is null) {                                            //If there is no teacher available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Teachers.Remove(deleteThisTeacher);                             //Removes the teacher from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the teacher to the database (removes it)

            return Ok(200);                                                            //Return status code 200 to confirm successful removal of teacher
            //return Ok(await dataContext.Teachers.ToListAsync());

        }

    }
}
