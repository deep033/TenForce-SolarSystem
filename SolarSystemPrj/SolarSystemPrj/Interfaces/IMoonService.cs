using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using SolarSystemPrj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystemPrj.Interfaces
{
    public interface IMoonService
    {
        List<Moon> GetMoons(List<BodyDto> bodies);
    }
}
