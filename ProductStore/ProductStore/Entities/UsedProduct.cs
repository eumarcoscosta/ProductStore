using System.Globalization;

namespace ProductStore.Entities
{
	public class UsedProduct : Product
	{

		public DateTime ManufactureDate { get; set; }

        public UsedProduct(DateTime manufactureDate, string name, double price) : base(name,price)
        {
            ManufactureDate = manufactureDate;
        }

        public UsedProduct()
		{
		}

        public override string PriceTag()
        {
            return Name
                + " (used) $ "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + " (Manufacture date: "
                + ManufactureDate.ToString("dd/MM/yyyy")
                + ")";
        }

    }
}

