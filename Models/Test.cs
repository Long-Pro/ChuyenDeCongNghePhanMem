using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDeCongNghePhanMem.Models
{
    [Keyless]
    public class Test
    {
        public int Order { get; set; }
    }
}
