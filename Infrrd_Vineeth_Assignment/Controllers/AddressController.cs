using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DTOs;
using DAL.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrrd_Vineeth_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILocationProvider _locationProvider;

        public AddressController(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;

        }
        [HttpPost]
        public async Task<ActionResult> AddLocation(LocationDTO locationDTO)
        {
            try
            {


                if (locationDTO != null)
                {
                    if (await _locationProvider.AddLocation(locationDTO))
                        return Ok();
                    else
                        return Problem();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return Problem();
            }
        }

    [HttpGet]
    public async Task<ActionResult> SearchAddress([FromQuery]string search,string sortBy="address",string sortOrder="asc")
    {
        try
        {


                if (!string.IsNullOrWhiteSpace(search) && search.Length >= 3)
                {
                    var result = (await _locationProvider.SearchAddress(search, sortBy, sortOrder));
                     return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
        }
        catch (Exception ex)
        {

            return Problem();
        }
    }
}
}
