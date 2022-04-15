using System.ComponentModel.DataAnnotations;

namespace ChuyenDeCongNghePhanMem.Models
{
    public class Stock
    {
        [Required(ErrorMessage = "Mã cổ phiếu không được trống")]
        public String mack { get; set; }

        [Required]
        [Range(1,long.MaxValue,ErrorMessage = "Số lượng > 0")]
        public long sl { get; set; }

        [Required]
        [Range(1.0f, float.MaxValue, ErrorMessage = "Giá > 0")]
        public float gia { get; set; }
        
        [Required]
        public String loai { get; set; }

        public Stock()
        {

        }
        public void show()
        {
            Console.WriteLine(String.Format("\nmack: {0}\nsl: {1}\ngia: {2}\n loai: {3}", mack, sl, gia, loai));

        }
        public void format()
        {
            if (mack != null) mack = mack.Trim();
        }
    }
}
