using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.OrdenDetalle
{
    public class ConsultaId
    {

        public class OrdenDetalleUnico : IRequest<TblOrdenesDetalle>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<OrdenDetalleUnico, TblOrdenesDetalle>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblOrdenesDetalle> Handle(OrdenDetalleUnico request, CancellationToken cancellationToken)
            {
                var ordenDetalle = await _context.TblOrdenesDetalles.FindAsync(request.Id);
                return ordenDetalle;
            }
        }
    }
}
