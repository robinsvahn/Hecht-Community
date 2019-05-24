using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HechtCommunity.Services.Impl
{
    internal class CoworkingServiceMock : ICoworkingService
    {
        private readonly Dictionary<int, bool> _tables;

        public CoworkingServiceMock()
        {
            _tables = new Dictionary<int, bool>
            {
                {1, false},
                {2, false},
                {3, false},
                {4, false},
                {5, false}
            };
        }
        public async Task<bool> IsTableVacant(int tableId)
        {
            return _tables[tableId];
        }

        public async Task<string> BookTableById(int tableId)
        {
            _tables[tableId] = true;
            return new HttpResponseMessage(HttpStatusCode.OK).ToString();
        }

        public async Task<string> UnbookTableById(int tableId)
        {
            _tables[tableId] = false;
            return new HttpResponseMessage(HttpStatusCode.OK).ToString();
        }
    }
}
