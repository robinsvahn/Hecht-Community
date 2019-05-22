using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HechtCommunity.Services
{
    public interface ICoworkingService
    {
        Task<bool> IsTableOccupiedById(int tableId);
        Task<HttpResponseMessage> BookTableById(int tableId);
        Task<HttpResponseMessage> UnbookTableById(int tableId);
    }
}
