
namespace CryptoScanner.Data.Models
{

        public class CryptoModel
        {
            public Bitcoin bitcoin { get; set; }
            public Dogecoin dogecoin { get; set; }
        }

        public class Bitcoin
        {
            public float sek { get; set; }
        }

        public class Dogecoin
        {
            public float sek { get; set; }
        }
}
