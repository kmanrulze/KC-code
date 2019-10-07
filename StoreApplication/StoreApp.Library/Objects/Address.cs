namespace StoreApplication
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public bool CheckAddress()
        {
            bool test = false;

            if(street != null && city != null && state != null && zip != null)
            {
                test = true;
            }
            else
            {
                test = false;
            }
            return test;
        }
    }
}