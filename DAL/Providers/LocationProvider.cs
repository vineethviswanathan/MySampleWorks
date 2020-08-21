using Common.DTOs;
using Common.Util;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Providers
{
    public class LocationProvider:ILocationProvider
    {
        private readonly MyDBContext _context;

        public LocationProvider(MyDBContext context)
        {
            _context = context;

        }
        public async Task<List<LocationDTO>> SearchAddress(string search, string sortBy, string sortOrder)
        { 
            try
            {

                var chars= search.ToCharArray();
               var locations =  await _context.Locations.Where(x =>
                x.Address.ToLower().Contains(search) ||
                x.City.ToLower().Contains(search) ||
                x.State.ToLower().Contains(search)
                ).Select(x => new LocationDTO
                {
                    Address = x.Address,
                    City = x.City,
                    ID = x.ID,
                    State = x.State,
                    ZIP = x.ZIP,
                    Frequency = (UtilHelper.GetMatchingCount(x.Address, search) * 1) + (UtilHelper.GetMatchingCount(x.City, search) * 2) +
                    (UtilHelper.GetMatchingCount(x.State, search) * 3)
                }).ToListAsync();


                if (sortBy.ToLower() == "address")
                {
                    if (sortOrder.ToLower() == "asc")
                    {
                        return locations.OrderBy(x => x.Address).ToList();
                    }
                    else
                    {
                        return locations.OrderByDescending(x => x.Address).ToList();
                    }
                }
                else
                {
                    if (sortOrder.ToLower() == "asc")
                    {
                       return locations.OrderBy(x => x.Frequency).ToList();
                    }
                    else
                    {
                       return locations.OrderByDescending(x => x.Frequency).ToList();
                    }
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> AddLocation(LocationDTO locationDTO)
        {
            Location location = null;
            try
            {

            
            if (locationDTO != null)
            {
                location = new Location();
                PropertyCopier<LocationDTO, Location>.Copy(locationDTO,location);
            }

            if (location!=null)
                _context.Locations.Add(location);
            else
                return false; 

            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }
    }
}
