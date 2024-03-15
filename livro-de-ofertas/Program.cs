using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Program{

    static void Main(){
        OrderBook orderBook = new OrderBook();

        Console.WriteLine("Informe o número de notificações:");

        int notificationsNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite a POSIÇÃO, AÇÃO, VALOR e QUANTIDADE desejados:");
        Console.WriteLine("AÇÕES:\n - 0: INSERIR\n - 1: MODIFICAR\n - 2: DELETAR");

        for(int i = 0; i < notificationsNumber; i++){
            string[] input = Console.ReadLine().Split(',');

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int position = int.Parse(input[0]);
            int action = int.Parse(input[1]);
            double value = double.Parse(input[2], CultureInfo.InvariantCulture);
            int quantity = int.Parse(input[3]);

            orderBook.UpdateOrderBook(position, action, value, quantity);
        }
        orderBook.ShowOrderBook();
    }

}

public class Order{
    public int Position {get; set;}
    public int Action {get; set;}
    public double Value {get; set;}
    public int Quantity {get; set;}

    public Order(int position, int action, double value, int quantity){
        Position = position;
        Action = action;
        Value = value;
        Quantity = quantity;
    }
}

public class OrderBook{
    private List<Order> orders;

    public OrderBook(){
        orders = new List<Order>();
    }

    public void UpdateOrderBook(int position, int action, double value, int quantity){
        
        Order order = new Order(position, action, value, quantity);

        if(action == 0){
            InsertOrder(order);
        }
        if(action == 1){
            ModifyOrder(order);
        }
        if(action == 2){
            DeleteOrder(order);
        }
    }

    public void InsertOrder(Order order){
        if(order.Position <= 0){
            throw new ArgumentException("Posição do Livro Inválida.");
        }
        if(order.Value <= 0){
            throw new ArgumentException("Valor do Livro Inválido.");
        }
        if(order.Quantity <= 0){
            throw new ArgumentException("Quantidade de Livros Inválida.");
        }
        orders.Add(order);
    }

    public void ModifyOrder(Order order){
        int index = orders.FindIndex(x => x.Position == order.Position);
        if(index != -1){
            orders[index].Value = order.Value;
            orders[index].Quantity = order.Quantity;
        }else{
            throw new ArgumentException("Posição de Livro Não Encontrada");
        }  
    }

    public void DeleteOrder(Order order){
        orders.RemoveAll(x => x.Position == order.Position);
    }

    public void ShowOrderBook(){
        Console.WriteLine("\nLISTA DE NOTIFICAÇÕES:");
        foreach(var order in orders){
            Console.WriteLine($"{order.Position}, {order.Value}, {order.Quantity}");
        }
    }
}