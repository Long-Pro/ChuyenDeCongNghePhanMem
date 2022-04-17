namespace ChuyenDeCongNghePhanMem.Models
{
    public class IdStock
    {
        public int Id { get; set; }

        public IdStock()
        {

        }
        public IdStock(int Id)
        {
            Id = Id;

        }
        public void show()
        {
            Console.WriteLine(String.Format("\nId: {0}\n", Id ));
        }

    }
}

