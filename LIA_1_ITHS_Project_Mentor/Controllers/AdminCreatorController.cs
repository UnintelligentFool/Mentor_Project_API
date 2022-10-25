namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCreatorController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public AdminCreatorController(DataContext dataContext) {                        //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetAdminCreator")]                                                   //Creates a GET for the /GetAdminCreator route to send back a list of all admincreators (only supposed to exist one!)
        public async Task<ActionResult<List<AdminCreator>>> GetAdminCreator() {         //Creates method for returning list of admincreators (should only exist one)

            List<AdminCreator> returnAdminCreator = await dataContext.AdminCreators.ToListAsync();//Creates a List variable of type AdminCreator that contains a list of all admincreators in the database (only supposed to exist one)

            if (returnAdminCreator is null) {                                           //If the list is empty execute this code

                return NotFound(404);                                                   // Send back a error message containing the status code 404

            }

            return Ok(returnAdminCreator);                                              //Sends back a list with all admincreators in the database

        }

        [HttpPatch("/UpdateAdminCreator")]                                              //Creates PATCH for route /UpdateAdminCreator to be used to send in new values to update the admincreator entry in the database
        public async Task<IActionResult> UpdateAdminCreator(int adminCreatorId, [FromBody] JsonPatchDocument<AdminCreator> newAdminCreatorValues) {// Creates method that takes in the id of the admincreator to PATCH and the values to use for the PATCH

            var updateThisAdminCreator = dataContext.AdminCreators.Find(adminCreatorId);//Finds admincreator to patch in the database and puts into a variable

            if (newAdminCreatorValues is null || updateThisAdminCreator is null) {      //If there is no admincreator to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newAdminCreatorValues.ApplyTo(updateThisAdminCreator);                      //Changes the values for the admincreator in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the admincreator entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisAdminCreator);

        }

    }
}
