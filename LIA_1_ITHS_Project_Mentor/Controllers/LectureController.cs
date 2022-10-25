namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public LectureController(DataContext dataContext) {                             //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetLecture/{id}")]                                                   //Creates GET for the /GetLecture route for the purpose of getting back the lecture with the matching id
        public async Task<ActionResult<Lecture>> GetLecture(int id) {                   //Takes in id in the database of the lecture to GET and send back

            var returnThisLecture = await dataContext.Lectures.FindAsync(id);           //Defines a variable for the lecture in the database so we can get it

            if (returnThisLecture is null) {                                            //if there is no lecture with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisLecture);                                               //Sends back the lecture that was requested

        }

        [HttpGet("/GetAllLectures/{courseId}")]                                         //Creates a GET for the /GetAllLectures route to send back a list of all lectures for specified course id
        public async Task<ActionResult<List<Lecture>>> GetAllLectures(int courseId) {   //Creates method for returning list of lectures for course

            List<Lecture> returnTheseLectures = await dataContext.Lectures.Where(source => source.CourseId == courseId).ToListAsync();//Creates a List variable of type Lecture that contains a list of all lectures for the specified course id in the database

            if (returnTheseLectures is null) {                                          //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseLectures);                                             //Sends back a list with all lectures for the specified course from the database

        }

        [HttpPost("/AddLecture")]                                                       //Creates POST for route /AddLecture to be able to add a lecture entry to the database
        public async Task<ActionResult<List<Lecture>>> AddLecture(Lecture newLecture) { //Creates method that takes in a variable of type  Lecture for adding a lecture entry to the database

            if (newLecture is null) {                                                   //If the received value of the lecture to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            dataContext.Lectures.Add(newLecture);                                       //Adds the lecture to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the lecture as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the lecture was successful
            //return Ok(await dataContext.Lectures.ToListAsync());

        }

        [HttpPatch("/UpdateLecture")]                                                   //Creates PATCH for route /UpdateLecture to be used to send in new values to update a lecture entry in the database
        public async Task<IActionResult> UpdateLecture(int lectureId, [FromBody] JsonPatchDocument<Lecture> newLectureValues) {// Creates method that takes in the id of the lecture to PATCH and the values to use for the PATCH

            var updateThisLecture = dataContext.Lectures.Find(lectureId);               //Finds lecture to patch in the database and puts into a variable

            if (newLectureValues is null || updateThisLecture is null) {                //If there is no lecture to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newLectureValues.ApplyTo(updateThisLecture);                                //Changes the values for the lecture in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the lecture entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisLecture);

        }

        [HttpDelete("/DeleteLecture/{lectureId}")]                                      //Creates DELETE for route /DeleteLecture that takes in id for lecture to delete from the database
        public async Task<ActionResult<List<Lecture>>> DeleteLecture(int lectureId) {   //Creates method to delete the lecture in the database with the received id

            var deleteThisLecture = dataContext.Lectures.Find(lectureId);               //Creates a variable that finds the specified lecture in the database

            if (deleteThisLecture is null) {                                            //If there is no lecture available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Lectures.Remove(deleteThisLecture);                             //Removes the lecture from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the lecture to the database (removes it)

            return Ok(200);                                                             //Return status code 200 to confirm successful removal of lecture
            //return Ok(await dataContext.Lectures.ToListAsync());

        }

    }
}
