using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleSystem.DAL.DBContext;
using SaleSystem.DAL.Interfaces;
using SaleSystem.Entity;

namespace SaleSystem.DAL.Implementation
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly Dbsale0014Context _dbContext;
        public SaleRepository(Dbsale0014Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> Register(Sale entity)
        {
            //throw new NotImplementedException();
            Sale saleGenerated = new Sale();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (SaleDetail item in entity.SaleDetails)
                    {
                        Product product_found = _dbContext.Products.Where(p => p.IdProduct == item.IdProduct).First();
                        product_found.Stock = product_found.Stock - item.Quantity;
                        _dbContext.Products.Update(product_found);                        
                    }
                    await _dbContext.SaveChangesAsync();
                    CorrelativeNumber correlative = _dbContext.CorrelativeNumbers.Where(n => n.Management == "sale").First();
                    correlative.LastNumber = correlative.LastNumber + 1;
                    correlative.UpdateDate = DateTime.Now;
                    _dbContext.CorrelativeNumbers.Update(correlative);
                    await _dbContext.SaveChangesAsync();
                    string zeros = string.Concat(Enumerable.Repeat("0", correlative.NumOfDigits.Value));
                    string saleNum = zeros + correlative.LastNumber.ToString();
                    saleNum = saleNum.Substring(saleNum.Length - correlative.NumOfDigits.Value, correlative.NumOfDigits.Value);
                    entity.SaleNumber = saleNum;
                    await _dbContext.Sales.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                    saleGenerated = entity;
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                     transaction.Rollback();
                     throw ex;
                }
            }
            return saleGenerated;
        }

        public async Task<List<SaleDetail>> Report(DateTime startDate, DateTime endDate)
        {
            //throw new NotImplementedException();
            List<SaleDetail> sumaryList = await _dbContext.SaleDetails
                .Include(s => s.IdSaleNavigation)
                .ThenInclude(u => u.IdUserAccountNavigation)
                .Include(s => s.IdSaleNavigation)
                .ThenInclude(sdt => sdt.IdSaleDocTypeNavigation)
                .Where(sd => sd.IdSaleNavigation.RegisterDate.Value.Date >= startDate.Date && sd.IdSaleNavigation.RegisterDate.Value.Date <= endDate.Date).ToListAsync();
            return sumaryList;
        }
    }
}
