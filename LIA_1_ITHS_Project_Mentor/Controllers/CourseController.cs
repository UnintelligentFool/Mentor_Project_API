namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public CourseController(DataContext dataContext) {                              //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetCourse/{id}")]                                                    //Creates GET for the /GetCourse route for the purpose of getting back the course with the matching id
        public async Task<ActionResult<Course>> GetCourse(int id) {                     //Takes in id in the database of the course to GET and send back

            var returnThisCourse = await dataContext.Courses.FindAsync(id);             //Defines a variable for the course in the database so we can get it

            if (returnThisCourse is null) {                                             //if there is no course with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisCourse);                                                //Sends back the course that was requested

        }

        [HttpGet("/GetAllCourses/{educationId}")]                                       //Creates a GET for the /GetAllCourses route to send back a list of all courses for specified education id
        public async Task<ActionResult<List<Course>>> GetAllCourses(int educationId) {  //Creates method for returning list of courses for education

            List<Course> returnTheseCourses = await dataContext.Courses.Where(source => source.EducationId == educationId).ToListAsync();//Creates a List variable of type Course that contains a list of all courses for the specified education id in the database

            if (returnTheseCourses is null) {                                           //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseCourses);                                              //Sends back a list with all courses for the specified education from the database

        }

        [HttpPost("/AddCourse")]                                                        //Creates POST for route /AddCourse to be able to add a course entry to the database
        public async Task<ActionResult<List<Course>>> AddCourse(Course newCourse) {     //Creates method that takes in a variable of type  Course for adding a course entry to the database

            if (newCourse is null) {                                                    //If the received value of the course to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            dataContext.Courses.Add(newCourse);                                         //Adds the course to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the course as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the course was successful
            //return Ok(await dataContext.Courses.ToListAsync());

        }

        [HttpPatch("/UpdateCourse")]                                                    //Creates PATCH for route /UpdateCourse to be used to send in new values to update a course entry in the database
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] JsonPatchDocument<Course> newCourseValues) {// Creates method that takes in the id of the course to PATCH and the values to use for the PATCH

            var updateThisCourse = dataContext.Courses.Find(courseId);                  //Finds course to patch in the database and puts into a variable

            if (newCourseValues is null || updateThisCourse is null) {                  //If there is no course to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newCourseValues.ApplyTo(updateThisCourse);                                  //Changes the values for the course in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the course entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisCourse);

        }

        [HttpDelete("/DeleteCourse/{courseId}")]                                       //Creates DELETE for route /DeleteCourse that takes in id for course to delete from the database
        public async Task<ActionResult<List<Course>>> DeleteCourse(int courseId) {     //Creates method to delete the course in the database with the received id

            var deleteThisCourse = dataContext.Courses.Find(courseId);                 //Creates a variable that finds the specified course in the database

            if (deleteThisCourse is null) {                                            //If there is no course available for the id received then execute this code

                return NotFound(404);                                                  //Send back status code 404 as a error code

            }

            dataContext.Courses.Remove(deleteThisCourse);                              //Removes the course from the datacontext

            await dataContext.SaveChangesAsync();                                      //Saves the removal of the course to the database (removes it)

            return Ok(200);                                                            //Return status code 200 to confirm successful removal of course
            //return Ok(await dataContext.Courses.ToListAsync());

        }

    }
}
