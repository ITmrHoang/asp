using System;
using System.Collections.Generic;
using System.Linq;
using NauAn.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NauAn.Models.Entities;

namespace NauAn.Models.ModelAction
{
    public class UserMA
    {
        private readonly DBNAContext _context;
        public UserMA(DBNAContext context)
        {
            _context = context;
        }
    }
}
