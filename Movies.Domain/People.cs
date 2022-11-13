using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain
{
    public abstract class People : Entity
    {
       public  string FirstName { get; set; }
       public  string LastName { get; set; }
    }

   
}
