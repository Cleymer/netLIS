﻿using Aplicacion.OrdenDetalle;
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
    public class OrdenDetalleController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblOrdenesDetalle>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("orden/{id}")]
        public async Task<ActionResult<List<TblOrdenesDetalle>>> Orden(Guid id)
        {
            return await Mediator.Send(new OrdenDetalleOrden.Ejecuta { Orden = id });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblOrdenesDetalle>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.OrdenDetalleUnico { Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}
