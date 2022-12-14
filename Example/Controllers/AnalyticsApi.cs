/*
 * Personal Finance Management API
 *
 * Personal Finance Management API allows analyze of a client's spending patterns against pre-defined budgets over time 
 *
 * OpenAPI spec version: v1
 * Contact: aleksandar.milosevic@asseco-see.rs
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Example.Attributes;
using Example.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Example.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AnalyticsApiController : ControllerBase
    { 
    
        [HttpGet]
        [Route("/v1/pfm/spending-analytics")]
        [ValidateModelState]
     
        public virtual IActionResult SpendingsGet([FromQuery]string catcode, [FromQuery]DateTime? startDate, [FromQuery]DateTime? endDate, [FromQuery]DirectionsEnum direction)
        { 
            
            string exampleJson = null;
            exampleJson = "{\n  \"groups\" : [ {\n    \"amount\" : 0.8008281904610115,\n    \"catcode\" : \"catcode\",\n    \"count\" : 6.027456183070403\n  }, {\n    \"amount\" : 0.8008281904610115,\n    \"catcode\" : \"catcode\",\n    \"count\" : 6.027456183070403\n  } ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<SpendingsByCategory>(exampleJson)
                        : default(SpendingsByCategory);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
