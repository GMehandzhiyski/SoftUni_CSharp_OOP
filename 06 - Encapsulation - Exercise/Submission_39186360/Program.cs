
using PizzaCalories.Model;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
               string tokens = string.Empty;
                string[] inputPizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] doughType = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Dough dough = new(doughType[1], doughType[2],double.Parse(doughType[3]));

                Pizza pizza = new(inputPizzaName[1], dough);

               while ((tokens = Console.ReadLine()) != "END") 
                {
                    string[] token = tokens
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Topping topping = new(token[1],double.Parse(token[2]));
                    pizza.AddToping(topping);
                }

                Console.WriteLine(pizza.ToString());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
