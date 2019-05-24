using System;
using System.Collections.Generic;
using System.Text;

namespace HechtCommunity.DTOs
{
    internal class TableDto
    {
        public TableDto(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
