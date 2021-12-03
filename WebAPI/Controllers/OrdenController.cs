using Aplicacion.Orden;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblOrdenes>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("paciente/{id}")]
        public async Task<ActionResult<List<TblOrdenes>>> Paciente(Guid id)
        {
            return await Mediator.Send(new OrdenPaciente.ConsultaPaciente { Paciente = id});
        }

        [HttpGet("tipoorden/{id}")]
        public async Task<ActionResult<List<TblOrdenes>>> TipoOrden(Guid id)
        {
            return await Mediator.Send(new OrdenTipo.ConsultaTipoOrden { TipoOrden = id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblOrdenes>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.OrdenUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
