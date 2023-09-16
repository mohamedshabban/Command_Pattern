namespace Command_Pattern
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var waiter=new Waiter();
			var kitchen=new Kitchen();

			waiter.TakeOrder(new MakePizzaCommand(kitchen));
			waiter.TakeOrder(new MakePizzaCommand(kitchen));
			waiter.PlaceOrders();

			Console.WriteLine("Hello, World!");
		}
	}
	public interface IOrderCommand
	{
		void Execute();
	}
	public class MakePizzaCommand : IOrderCommand
	{
		private readonly Kitchen kitchen;

		public MakePizzaCommand(Kitchen kitchen)
        {
			this.kitchen = kitchen;
		}
        public void Execute()
		{
			kitchen.PreparePizza();
		}
	}
	public class Kitchen
	{
		public void PreparePizza()
		{
            Console.WriteLine("Prepare Pizza.......!");
        }
		public void PreparePasta()
		{
			Console.WriteLine("Prepare Pasta.......!");
		}
	}
	public class Waiter
	{
		private readonly List<IOrderCommand> orders = new();
		public void PlaceOrders()
		{
			foreach (var command in orders)
			{
				command.Execute();
			}
			orders.Clear();
		}
		public void TakeOrder(IOrderCommand orderCommand)
		{
			orders.Add(orderCommand);
		}
	}
}