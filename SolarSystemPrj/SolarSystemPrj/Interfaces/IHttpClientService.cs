using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Interfaces
{
    public interface IHttpClientService
    {
        Task<List<BodyDto>> GetBodiesAsync();
    }
}
