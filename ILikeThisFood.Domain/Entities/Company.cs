﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string RegistreNumber { get; private set; }
    }
}