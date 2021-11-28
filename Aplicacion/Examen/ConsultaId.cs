using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examen
{
    public class ConsultaId
    {

        public class ExamenUnico: IRequest<TblExamenes>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ExamenUnico, TblExamenes>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblExamenes> Handle(ExamenUnico request, CancellationToken cancellationToken)
            {
                var examen = await _context.TblExamenes.FindAsync(request.Id);
                return examen;
            }
        }
    }
}
