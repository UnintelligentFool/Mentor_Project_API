namespace LIA_1_ITHS_Project_Mentor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolContactPersonController : ControllerBase {

        private readonly DataContext dataContext;                                       // Creates DataContext variable

        public SchoolContactPersonController(DataContext dataContext) {                 //Creates constuctor

            this.dataContext = dataContext;                                             //Sets value of DataContext variable to the DataContext.cs

        }

        [HttpGet("/GetSchoolContactPerson/{schoolId}/{id}")]                            //Creates GET for the /GetSchoolContactPerson route for the purpose of getting back the SchoolContactPerson with the matching id that is a contact person at the school with the specified school id
        public async Task<ActionResult<SchoolContactPerson>> GetSchoolContactPerson(int id, int schoolId) { //Takes in id in the database of the school the schoolcontactperson is connected to and the id of the schoolcontactperson in the database to GET and send back

            var returnThisSchoolContactPerson = await dataContext.SchoolContactPersons.Where(source => source.SchoolId == schoolId).ToListAsync(); //Defines a variable that creates a list of schoolcontactpersons that have the specified school id in the database so we can get a schoolcontactperson from it to return later

            if (returnThisSchoolContactPerson.Where(source => source.Id == id) is null) { //if there is no schoolcontactperson with the specified school id and the specified id this will return a status code as a error

                return NotFound(404);                                                   //Returns status code 404 since there doesn't exist a entry in the database

            }

            return Ok(returnThisSchoolContactPerson.Where(source => source.Id == id));  //Sends back the schoolcontactperson that has the specified id

        }

        [HttpGet("/GetAllSchoolContactPersons/{schoolId}")]                             //Creates a GET for the /GetAllSchoolContactPersons route to send back a list of all schoolcontactpersons for specified school id
        public async Task<ActionResult<List<SchoolContactPerson>>> GetAllSchoolContactPersons(int schoolId) {  //Creates method for returning list of schoolcontactpersons for specified school

            List<SchoolContactPerson> returnTheseSchoolContactPersons = await dataContext.SchoolContactPersons.Where(source => source.SchoolId == schoolId).ToListAsync();//Creates a List variable of type SchoolContactPerson that contains a list of all schoolcontactpersons for the specified school id in the database

            if (returnTheseSchoolContactPersons is null) {                              //If the list is empty execute this code

                return NotFound(404);                                                   //Send back a error message containing the status code 404

            }

            return Ok(returnTheseSchoolContactPersons);                                 //Sends back a list with all schoolcontactpersons for the specified school from the database

        }

        [HttpPost("/AddSchoolContactPersons")]                                          //Creates POST for route /AddSchoolContactPersons to be able to add a list of schoolcontactpersons entries to the database
        public async Task<ActionResult<List<SchoolContactPerson>>> AddSchoolContactPersons(List<SchoolContactPerson> newSchoolContactPersons) { //Creates method that takes in a variable of type List<SchoolContactPerson> for adding a list of schoolcontactperson entries to the database

            if (newSchoolContactPersons is null) {                                      //If the received value of the schoolcontactperson list to add is null/empty run this code

                return BadRequest(400);                                                 //Send back status code 400 as a error message

            }

            foreach (SchoolContactPerson schoolContactPerson in newSchoolContactPersons) { //Goes through each schoolcontactperson in the list of schoolcontactpersons received and executes the code below

                dataContext.SchoolContactPersons.Add(schoolContactPerson);                 //Adds schoolcontactpersons to the DataContext

            }

            await dataContext.SaveChangesAsync();                                       //Saves the list of schoolcontactpersons as entries in the database

            return Ok(201);                                                             //Sends back status code 201 as confirmation that the task to add the list of schoolcontactpersons was successful
            //return Ok(await dataContext.SchoolContactPersons.ToListAsync());

        }

        [HttpPatch("/UpdateSchoolContactPerson")]                                       //Creates PATCH for route /UpdateSchoolContactPerson to be used to send in new values to update a schoolcontactperson entry in the database
        public async Task<IActionResult> UpdateSchoolContactPerson(int schoolContactPersonId, [FromBody] JsonPatchDocument<SchoolContactPerson> newSchoolContactPersonValues) { // Creates method that takes in the id of the schoolcontactperson to PATCH and the values to use for the PATCH

            var updateThisSchoolContactPerson = dataContext.SchoolContactPersons.Find(schoolContactPersonId); //Finds schoolcontactperson to patch in the database and puts into a variable

            if (newSchoolContactPersonValues is null || updateThisSchoolContactPerson is null) { //If there is no schoolcontactperson to be found that fits the value received or if no value was received execute the following code

                return NotFound(404);                                                   //Send back the status code 404 as a error code

            }

            newSchoolContactPersonValues.ApplyTo(updateThisSchoolContactPerson);        //Changes the values for the schoolcontactperson in the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the patched values for the schoolcontactperson entry to the database

            return Ok(200);                                                             //Returns status code 200 to confirm success
            //return Ok(updateThisSchoolContactPerson);

        }

        [HttpDelete("/DeleteSchoolContactPerson/{schoolContactPersonId}")]              //Creates DELETE for route /DeleteSchoolContactPerson that takes in id for schoolcontactperson to delete from the database
        public async Task<ActionResult<List<SchoolContactPerson>>> DeleteSchoolContactPerson(int schoolContactPersonId) { //Creates method to delete the schoolcontactperson in the database with the received id

            var deleteThisSchoolContactPerson = dataContext.SchoolContactPersons.Find(schoolContactPersonId);             //Creates a variable that finds the specified schoolcontactperson in the database

            if (deleteThisSchoolContactPerson is null) {                                //If there is no schoolcontactperson available for the id received then execute this code

                return NotFound(404);                                                   //Send back status code 404 as a error code

            }

            dataContext.SchoolContactPersons.Remove(deleteThisSchoolContactPerson);     //Removes the schoolcontactperson from the datacontext

            await dataContext.SaveChangesAsync();                                       //Saves the removal of the schoolcontactperson to the database (removes it)

            return Ok(200);                                                            //Return status code 200 to confirm successful removal of schoolcontactperson
            //return Ok(dataContext.SchoolContactPersons.ToListAsync());

        }

    }
}
