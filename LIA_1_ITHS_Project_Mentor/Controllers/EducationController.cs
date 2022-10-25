namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public EducationController(DataContext dataContext) {                           //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetEducation/{id}")]                                                 //Creates GET for the /GetEducation route for the purpose of getting back the education with the matching id
        public async Task<ActionResult<Education>> GetEducation(int id) {               //Takes in id in the database of the education to GET and send back

            var returnThisEducation = await dataContext.Educations.FindAsync(id);       //Defines a variable for the education in the database so we can get it

            if (returnThisEducation is null) {                                          //if there is no education with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisEducation);                                             //Sends back the education that was requested

        }

        [HttpGet("/GetAllEducationsAtSchool/{schoolId}")]                               //Creates a GET for the /GetAllEducationsAtSchool route to send back a list of all educations for specified school id
        public async Task<ActionResult<List<Education>>> GetAllEducationsAtSchool(int schoolId) { //Creates method for returning list of educations at specified school

            List<Education> returnTheseEducations = await dataContext.Educations.Where(source => source.SchoolId == schoolId).ToListAsync();//Creates a List variable of type Education that contains a list of all educations for the specified school id in the database

            if (returnTheseEducations is null) {                                        //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseEducations);                                           //Sends back a list with all educations for the specified school from the database

        }

        [HttpGet("/GetAllEducations")]                                                  //Creates a GET for the /GetAllEducations route to send back a list of all educations
        public async Task<ActionResult<List<Education>>> GetAllEducations() {           //Creates method for returning list of all educations

            List<Education> returnTheseEducations = await dataContext.Educations.ToListAsync(); //Creates a List variable of type Education that contains a list of all educations in the database

            if (returnTheseEducations is null) {                                        //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseEducations);                                           //Sends back a list with all educations in the database

        }

        [HttpPost("/AddEducation")]                                                     //Creates POST for route /AddEducation to be able to add a education entry to the database
        public async Task<ActionResult<List<Education>>> AddEducation(Education newEducation) { //Creates method that takes in a variable of type Education for adding a education entry to the database

            if (newEducation is null) {                                                 //If the received value of the education to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            dataContext.Educations.Add(newEducation);                                   //Adds the education to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the education as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the education was successful
            //return Ok(await dataContext.Educations.ToListAsync());

        }

        [HttpPatch("/UpdateEducation")]                                                 //Creates PATCH for route /UpdateEducation to be used to send in new values to update a education entry in the database
        public async Task<IActionResult> UpdateEducation(int educationId, [FromBody] JsonPatchDocument<Education> newEducationValues) { // Creates method that takes in the id of the education to PATCH and the values to use for the PATCH

            var updateThisEducation = dataContext.Educations.Find(educationId);         //Finds education to patch in the database and puts into a variable

            if (newEducationValues is null || updateThisEducation is null) {            //If there is no education to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newEducationValues.ApplyTo(updateThisEducation);                            //Changes the values for the education in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the education entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisEducation);

        }

        [HttpDelete("/DeleteEducation/{educationId}")]                                  //Creates DELETE for route /DeleteEducation that takes in id for education to delete from the database
        public async Task<ActionResult<List<Education>>> DeleteEducation(int educationId) { //Creates method to delete the education in the database with the received id

            var deleteThisEducation = dataContext.Educations.Find(educationId);         //Creates a variable that finds the specified education in the database

            if (deleteThisEducation is null) {                                          //If there is no education available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Educations.Remove(deleteThisEducation);                         //Removes the education from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the education to the database (removes it)

            return Ok(200);                                                            //Return status code 200 to confirm successful removal of education
            //return Ok(await dataContext.Educations.ToListAsync());

        }

    }
}
