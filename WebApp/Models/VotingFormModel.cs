using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace WebApp.Models
{
    public class VotingFormModel
    {
        public int Company_Id { get; set; }
        public int Evaluation { get; set; }
        public string Comment { get; set; }
    }
}