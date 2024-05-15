using EX.Core.Domain;
using EX.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Services
{
    public class PresationService : Service<Presation>, IPresationService
    {
        public PresationService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
