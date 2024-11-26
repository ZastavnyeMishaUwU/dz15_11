namespace ConsoleApp3
{
    struct Article
    {
        public int Code;
        public string Name;
        public decimal Price;

        public Article(int code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} (Code: {Code}, Price: {Price:C})";
        }
    }

    struct Client
    {
        public int ClientId;
        public string FullName;
        public string Address;
        public string Phone;
        public int OrdersCount;
        public decimal TotalOrderSum;

        public Client(int clientId, string fullName, string address, string phone, int ordersCount, decimal totalOrderSum)
        {
            ClientId = clientId;
            FullName = fullName;
            Address = address;
            Phone = phone;
            OrdersCount = ordersCount;
            TotalOrderSum = totalOrderSum;
        }
    }

    struct RequestItem
    {
        public Article Item;
        public int Quantity;

        public RequestItem(Article item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return Item.Price * Quantity;
        }
    }

    struct Request
    {
        public int RequestId;
        public Client Client;
        public DateTime RequestDate;
        public RequestItem[] Items; 
        public decimal TotalSum;

        public Request(int requestId, Client client, DateTime requestDate, RequestItem[] items)
        {
            RequestId = requestId;
            Client = client;
            RequestDate = requestDate;
            Items = items;
            TotalSum = CalculateTotalSum();
        }

        private decimal CalculateTotalSum()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.GetTotalPrice();
            }
            return total;
        }
    }

    enum ArticleType
    {
        Food,
        Electronics,
        Clothing,
        Furniture,
        Other
    }

    enum ClientType
    {
        Regular,
        VIP,
        Wholesale
    }

    enum PayType
    {
        Cash,
        Card,
        Online
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Article article1 = new Article(1, "ЖУРНАЛ РОСИНКА", 1500.99m);
            Article article2 = new Article(2, "ГОДИНИК НАПОЛЕОНА", 799.49m);

            Client client = new Client(1, "ІГОР", "Київ, Кажакстан", "+380123456789", 5, 3000m);

      
            RequestItem[] items = new RequestItem[]
            {
                new RequestItem(article1, 2),
                new RequestItem(article2, 1)
            };

            Request request = new Request(1, client, DateTime.Now, items);

            Console.WriteLine($"айдішнік: {request.RequestId}");
            Console.WriteLine($"Клієнт: {request.Client.FullName}");
            Console.WriteLine($"загальна сума: {request.TotalSum:C}");
        }
    }
}
