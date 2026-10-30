using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheater.Domain.Enums;  

public enum BookingStatus
{
    Pending = 1,
    Confirmed = 2,
    Expired = 3,
    Cancelled = 4
}
