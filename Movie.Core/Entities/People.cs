﻿using Movie.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Entities
{
    public abstract class People : Entity
    {
       public  string FirstName { get; set; }
       public  string LastName { get; set; }
    }

   
}
