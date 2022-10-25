namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public SchoolController(DataContext dataContext) {                              //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetSchool/{id}")]                                                    //Creates GET for the /GetSchool route for the purpose of getting back the school with the matching id
        public async Task<ActionResult<School>> GetSchool(int id) {                     //Takes in id in the database of the school to GET and send back

            var returnThisSchool = await dataContext.Schools.FindAsync(id);             //Defines a variable for the school in the database so we can get it

            if (returnThisSchool is null) {                                             //if there is no school with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisSchool);                                                //Sends back the school that was requested

        }

        [HttpGet("/GetAllSchools")]                                                     //Creates a GET for the /GetAllSchools route to send back a list of all schools
        public async Task<ActionResult<List<School>>> GetAllSchools() {                 //Creates method for returning list of schools

            List<School> returnTheseSchools = await dataContext.Schools.ToListAsync();  //Creates a List variable of type School that contains a list of all schools in the database

            if (returnTheseSchools is null) {                                           //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseSchools);                                              //Sends back a list with all schools in the database

        }

        [HttpPost("/AddSchool")]                                                        //Creates POST for route /AddSchool to be able to add a school entry to the database
        public async Task<ActionResult<List<School>>> AddSchool(School newSchool) {     //Creates method that takes in a variable of type  School for adding a school entry to the database

            if (newSchool is null) {                                                    //If the received value of the school to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message
            
            }

            dataContext.Schools.Add(newSchool);                                         //Adds the school to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the school as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the school was successful
            //return Ok(await dataContext.Schools.ToListAsync());

        }

        [HttpPatch("/UpdateSchool")]                                                    //Creates PATCH for route /UpdateSchool to be used to send in new values to update a school entry in the database
        public async Task<IActionResult> UpdateSchool(int schoolId, [FromBody] JsonPatchDocument<School> newSchoolValues) {// Creates method that takes in the id of the school to PATCH and the values to use for the PATCH

            var updateThisSchool = dataContext.Schools.Find(schoolId);                  //Finds school to patch in the database and puts into a variable

            if (newSchoolValues is null || updateThisSchool is null) {                  //If there is no school to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newSchoolValues.ApplyTo(updateThisSchool);                                  //Changes the values for the school in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the school entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisSchool);

        }

        [HttpDelete("/DeleteSchool/{schoolId}")]                                        //Creates DELETE for route /DeleteSchool that takes in id for school to delete from the database
        public async Task<ActionResult<List<School>>> DeleteSchool(int schoolId) {      //Creates method to delete the school in the database with the received id

            var deleteThisSchool = dataContext.Schools.Find(schoolId);                  //Creates a variable that finds the specified school in the database

            if (deleteThisSchool is null) {                                             //If there is no school available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Schools.Remove(deleteThisSchool);                               //Removes the school from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the school to the database (removes it)

            return Ok(200);                                                             //Return status code 200 to confirm successful removal of school
            //return Ok(await dataContext.Schools.ToListAsync());

        }

    }

}
