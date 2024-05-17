using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljettshoppen.Interfaces
{
    public interface iOcassion
    {
        string OcassionName { get; set;}
        string OcassionPerformer { get; set; }
        DateTime OcassionDate { get; set; }
        string OcassionType { get; set; }
    }
}
