using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Providers
{
    public interface ILocationProvider
    {
        Task<List<LocationDTO>> SearchAddress(string search, string sortBy, string sortOrder);

        Task<bool> AddLocation(LocationDTO locationDTO);
    }
}
