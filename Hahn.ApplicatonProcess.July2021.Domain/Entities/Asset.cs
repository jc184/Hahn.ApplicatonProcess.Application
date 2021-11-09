﻿using Hahn.ApplicatonProcess.July2021.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class Asset : BaseEntity<int>
    {
        //public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }  
    }
}
