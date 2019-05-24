using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HechtCommunity.Services
{
    public interface ICoworkingService
    {
        Task<bool> IsTableVacant(int tableId);
        Task<string> BookTableById(int tableId);
        Task<string> UnbookTableById(int tableId);
    }
}
