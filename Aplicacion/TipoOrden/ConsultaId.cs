using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoOrden
{
    public class ConsultaId
    {

        public class TipoOrdenUnico : IRequest<TblCatTipoOrden>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoOrdenUnico, TblCatTipoOrden>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoOrden> Handle(TipoOrdenUnico request, CancellationToken cancellationToken)
            {
                var tipoOrden = await _context.TblCatTipoOrdens.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return tipoOrden;
            }
        }

    }
}
