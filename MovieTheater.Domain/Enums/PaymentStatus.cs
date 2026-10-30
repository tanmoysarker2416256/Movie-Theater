using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater.Domain.Enums; 

public enum PaymentStatus
{
    Initiated=1,
    Succeeded=2,
    Failed=3,
    Cancelled=4
}
