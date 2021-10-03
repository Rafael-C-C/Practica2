using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnApp.Entities;
using System.Text.Json;

namespace AnApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnaController : ControllerBase
    {
        [HttpPost]
        public string POST(Palabra dto)
        {
            string palabra1 = String.Concat(dto.Palabra_1.ToLower().OrderBy(c => c));
            string palabra2 = String.Concat(dto.Palabra_2.ToLower().OrderBy(c => c));
            string msg;

            if (palabra1 == palabra2)
            {
                msg = "Estas palbras son Anagrama un de la otra";
            }
            else
            {
                msg = "No Son Anagramas, prueba con estas: ";
            }

            Anagrama anagrama = new Anagrama()
            {
                Palabra_1 = dto.Palabra_1,
                Palabra_2 = dto.Palabra_2,
                Estatus = msg,
            };

            string json = JsonSerializer.Serialize(anagrama);

            return json;
        }
    }
}