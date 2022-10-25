namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LectureFileController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public LectureFileController(DataContext dataContext) {                         //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetLectureFile/{id}")]                                               //Creates GET for the /GetLectureFile route for the purpose of getting back the lecturefile with the matching id
        public async Task<ActionResult<LectureFile>> GetLectureFile(int id) {           //Takes in id in the database of the lecturefile to GET and send back

            var returnThisLectureFile = await dataContext.LectureFiles.FindAsync(id);   //Defines a variable for the lecturefile in the database so we can get it

            if (returnThisLectureFile is null) {                                        //if there is no lecturefile with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisLectureFile);                                           //Sends back the lecturefile that was requested

        }

        [HttpGet("/GetAllLectureFiles/{lectureId}")]                                    //Creates a GET for the /GetAllLectureFiles route to send back a list of all lecturefiles for specified lecture id
        public async Task<ActionResult<List<LectureFile>>> GetAllLectureFiles(int lectureId) {//Creates method for returning list of lecturefiles for specified lecture

            List<LectureFile> returnTheseLectureFiles = await dataContext.LectureFiles.Where(source => source.LectureId == lectureId).ToListAsync();//Creates a List variable of type Lecturefile that contains a list of all lecturefiles for the specified lecture id in the database

            if (returnTheseLectureFiles is null) {                                      //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseLectureFiles);                                         //Sends back a list with all lecturefiles for the specified lecture from the database

        }

        [HttpPost("/AddLectureFile")]                                                   //Creates POST for route /AddLectureFile to be able to add a lecturefile entry to the database
        public async Task<ActionResult<List<LectureFile>>> AddLectureFile(LectureFile newLectureFile) {//Creates method that takes in a variable of type  LectureFile for adding a lecturefile entry to the database

            if (newLectureFile is null) {                                               //If the received value of the lecturefile to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            dataContext.LectureFiles.Add(newLectureFile);                               //Adds the lecturefile to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the lecturefile as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the lecturefile was successful
            //return Ok(await dataContext.LectureFiles.ToListAsync());

        }

        [HttpDelete("/DeleteLectureFile/{lectureFileId}")]                              //Creates DELETE for route /DeleteLectureFile that takes in id for lecturefile to delete from the database
        public async Task<ActionResult<List<LectureFile>>> DeleteLectureFile(int lectureFileId) {//Creates method to delete the lecturefile in the database with the received id

            var deleteThisLectureFile = dataContext.LectureFiles.Find(lectureFileId);   //Creates a variable that finds the specified lecturefile in the database

            if (deleteThisLectureFile is null) {                                        //If there is no lecturefile available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.LectureFiles.Remove(deleteThisLectureFile);                     //Removes the lecturefile from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the lecturefile to the database (removes it)

            return Ok(200);                                                             //Return status code 200 to confirm successful removal of lecturefile
            //return Ok(await dataContext.LectureFiles.ToListAsync());

        }

    }
}
