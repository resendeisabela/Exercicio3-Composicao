using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio3Composicao.Entities;
using exercicio3Composicao.Entities.Enums;

namespace exercicio3Composicao
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());
            Console.Write("How many items to this order? ");
            int numItems = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            for (int i = 0; i < numItems; i++)
            {
                Console.WriteLine("\nEnter #" + (i + 1) + " item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, price);
                OrderItem orderItem = new OrderItem(quant, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine(order.ToString());
            Console.ReadLine();
        }
    }
}
