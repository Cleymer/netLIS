using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Orden
{
    public class ConsultaId
    {

        public class OrdenUnico : IRequest<TblOrdenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<OrdenUnico, TblOrdenes>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblOrdenes> Handle(OrdenUnico request, CancellationToken cancellationToken)
            {
                var orden = await _context.TblOrdenes.FindAsync(request.Id);
                return orden;
            }
        }
    }
}
