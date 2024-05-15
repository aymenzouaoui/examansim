using EX.Core.Domain;
using EX.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX.Core.Services
{
    public class SpecialiteService : Service<Specialite>, ISpecialiteService
    {
        public SpecialiteService(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
