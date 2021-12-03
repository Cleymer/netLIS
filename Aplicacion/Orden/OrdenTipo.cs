using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Orden
{
    public class OrdenTipo
    {
        public class ConsultaTipoOrden : IRequest<List<TblOrdenes>>
        {
            public Guid TipoOrden { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultaTipoOrden, List<TblOrdenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblOrdenes>> Handle(ConsultaTipoOrden request, CancellationToken cancellationToken)
            {
                var ordenes = await _context.TblOrdenes.Where(x => x.IdTipoOrden == request.TipoOrden).ToListAsync();
                return ordenes;
            }
        }

    }
}
