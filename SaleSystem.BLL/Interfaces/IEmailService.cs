using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.BLL.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string DestEmail, string Subject, string Msg);
    }
}
