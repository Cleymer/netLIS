using Aplicacion.Examen;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblExamenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblExamenes>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.ExamenUnico { Id = id });
        }
    }
}
