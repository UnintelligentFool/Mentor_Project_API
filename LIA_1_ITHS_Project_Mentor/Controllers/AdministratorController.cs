namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public AdministratorController(DataContext dataContext) {                       //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetAdministrator/{id}")]                                             //Creates GET for the /GetAdministrator route for the purpose of getting back the administrator with the matching id
        public async Task<ActionResult<Administrator>> GetAdministrator(int id) {       //Takes in id in the database of the administrator to GET and send back

            var returnThisAdministrator = await dataContext.Administrators.FindAsync(id);//Defines a variable for the administrator in the database so we can get it

            if (returnThisAdministrator is null) {                                       //if there is no administrator with the id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisAdministrator);                                         //Sends back the administrator that was requested

        }

        [HttpGet("/GetAllAdministrators")]                                              //Creates a GET for the /GetAllAdministrators route to send back a list of all administrators
        public async Task<ActionResult<List<Administrator>>> GetAllAdministrators() {   //Creates method for returning list of administrators

            List<Administrator> returnTheseAdministrators = await dataContext.Administrators.ToListAsync();//Creates a List variable of type Administrator that contains a list of all administrators in the database

            if (returnTheseAdministrators is null) {                                    //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseAdministrators);                                       //Sends back a list with all administrators in the database

        }

        [HttpPost("/AddAdministrator")]                                                 //Creates POST for route /AddAdministrator to be able to add a administrator entry to the database
        public async Task<ActionResult<List<Administrator>>> AddAdministrator(Administrator newAdministrator) {//Creates method that takes in a variable of type  Administrator for adding a administrator entry to the database

            if (newAdministrator is null) {                                             //If the received value of the administrator to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            dataContext.Administrators.Add(newAdministrator);                           //Adds the administrator to the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the administrator as a entry in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the administrator was successful
            //return Ok(await dataContext.Administrators.ToListAsync());

        }

        [HttpPatch("/UpdateAdministrator")]                                             //Creates PATCH for route /UpdateAdministrator to be used to send in new values to update a administrator entry in the database
        public async Task<IActionResult> UpdateAdministrator(int administratorId, [FromBody] JsonPatchDocument<Administrator> newAdministratorValues) {// Creates method that takes in the id of the administrator to PATCH and the values to use for the PATCH

            var updateThisAdministrator = dataContext.Administrators.Find(administratorId);//Finds administrator to patch in the database and puts into a variable

            if (newAdministratorValues is null || updateThisAdministrator is null) {    //If there is no administrator to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newAdministratorValues.ApplyTo(updateThisAdministrator);                    //Changes the values for the administrator in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the administrator entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisAdministrator);

        }

        [HttpDelete("/DeleteAdministrator/{administratorId}")]                          //Creates DELETE for route /DeleteAdministrator that takes in id for administrator to delete from the database
        public async Task<ActionResult<List<Administrator>>> DeleteAdministrator(int administratorId) {//Creates method to delete the administrator in the database with the received id

            var deleteThisAdministrator = dataContext.Administrators.Find(administratorId);//Creates a variable that finds the specified administrator in the database

            if (deleteThisAdministrator is null) {                                      //If there is no administrator available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.Administrators.Remove(deleteThisAdministrator);                 //Removes the administrator from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the administrator to the database (removes it)

            return Ok(200);                                                             //Return status code 200 to confirm successful removal of administrator
            //return Ok(await dataContext.Administrators.ToListAsync());

        }

    }
}
