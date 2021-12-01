using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Perfiles;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PerfilController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatPerfiles>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

    }
}
