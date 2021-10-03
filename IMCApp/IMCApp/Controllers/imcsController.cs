using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IMCApp.Entities;
using System.Text.Json;

namespace PIMC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class imcscontroller : ControllerBase
    {
        [HttpPost]
        public string POST(Person dto)
        {
            double resul = Math.Round((dto.peso / (Math.Pow((dto.altura/100), 2))), 2);
            string msg = "";

            if(resul < 18.5)
            {
                msg = "Tu Peso Es Inferior Al Normal.";
            }

            if(resul >= 18.5 && resul <= 24.9)
            {
                msg = "Tu Peso Es Normal.";
            }

            if(resul > 24.9 && resul <= 29.9)
            {
                msg = "Tu Peso Es superior Al Normal.";
            }

            if(resul > 29.9)
            {
                msg = "Tienes Obesidad.";
            }

            IMC imc = new IMC()
            {
                imc = resul,
                c_corporal = msg

            };

            string json = JsonSerializer.Serialize(imc);

            return json;
        }

        
    }
}