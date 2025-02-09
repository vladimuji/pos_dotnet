using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleSystem.Entity;

namespace SaleSystem.DAL.Interfaces
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale sale);
        Task<List<SaleDetail>> Report(DateTime startDate, DateTime endDate);
    }
}
