using System.Text.Json;

// Simulando dados de pedidos
var orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "John Doe", ProductId = 1 },
            new Order { Id = 2, CustomerName = "Jane Smith", ProductId = 2 },
            new Order { Id = 3, CustomerName = "Bob Johnson", ProductId = 1 },
            new Order { Id = 4, CustomerName = "CPD 853", ProductId = 3 },
        };

// Simulando dados de produtos
var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99 },
            new Product { Id = 2, Name = "Product B", Price = 20.50 },
            new Product { Id = 3, Name = "Product C", Price = 5.75 }
        };

// Realizando um join entre pedidos e produtos
var query = from order in orders
            join product in products on order.ProductId equals product.Id
            // where product.Price > 10.00
            select new
            {
                order.Id,
                order.CustomerName,
                ProductName = product.Name,
                product.Price
            };

// Join com linq method
//var query = orders.Join(products,
//                        order => order.ProductId,
//                        product => product.Id,
//                        (order, product) => new
//                        {
//                            order.Id,
//                            order.CustomerName,
//                            ProductName = product.Name,
//                            product.Price
//                        });

// Convertendo o resultado para JSON
var resultJson = JsonSerializer.Serialize(query, new JsonSerializerOptions { WriteIndented = true });

// Exibindo o resultado
Console.WriteLine("Resultado do join entre pedidos e produtos:");
Console.WriteLine(resultJson);

// Definindo as classes de Pedido e Produto
class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public int ProductId { get; set; }
}

class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
}