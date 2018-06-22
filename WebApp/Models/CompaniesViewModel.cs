using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace WebApp.Models
{
    public class ComaniesViewModel
    {
        public List<Company> Companies { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}