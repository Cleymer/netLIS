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
    public class OrdenPaciente
    {

        public class ConsultaPaciente : IRequest<List<TblOrdenes>>
        {
            public Guid Paciente { get; set; }
        }

        public class Manejador : IRequestHandler<ConsultaPaciente, List<TblOrdenes>>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<List<TblOrdenes>> Handle(ConsultaPaciente request, CancellationToken cancellationToken)
            {
                var ordenes = await _context.TblOrdenes.Where(x => x.IdPaciente == request.Paciente).ToListAsync();
                return ordenes;
            }

        }
    }
}
