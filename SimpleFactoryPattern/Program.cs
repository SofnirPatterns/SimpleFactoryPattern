using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore pizzaStore = new PizzaStore(new SimplePizzaFactory());
            pizzaStore.OrderPizza(PizzaType.Cheese);
            Console.WriteLine();
            pizzaStore.OrderPizza(PizzaType.Ham);
            Console.ReadKey();
        }

        public enum PizzaType
        {
            Cheese,
            Ham
        }

        public abstract class Pizza
        {
            protected string Name;
            protected string Dough = "Thin Crust Dough";                
            protected string Sauce = "Marinara Sauce";
            protected List<string> Toppings = new List<string>();

            public void Prepare()
            {
                Console.WriteLine($"Preparing {this.Name}");
                Console.WriteLine($"Tossing dough...");
                Console.WriteLine($"Adding sauce...");
                Console.WriteLine($"Adding toppings...");
                foreach (string topping in this.Toppings)
                {
                    Console.WriteLine($" {topping}");
                }
            }

            public void Bake()
            {
                Console.WriteLine("Bake for 25 miutes at 350");
            }

            public void Cut()
            {
                Console.WriteLine("Cutting the pizza into diagonal slices");
            }

            public void Box()
            {
                Console.WriteLine("Place pizza in offical PizzaStore box");
            }
        }

        public class CheseePizza : Pizza
        {
            public CheseePizza()
            {
                this.Name = "Cheese pizza";                
                this.Toppings.Add("Grated Reggiano Cheese");
            }
        }

        public class HamPizza : Pizza
        {
            public HamPizza()
            {
                this.Name = "Ham pizza";
                this.Toppings.Add("Ham");
            }
        }

        public class SimplePizzaFactory
        {
            public Pizza CreatePizza(PizzaType type)
            {
                Pizza pizza = null;                
                switch (type)
                {
                    case PizzaType.Cheese:
                        pizza =  new CheseePizza();
                        break;
                    case PizzaType.Ham:
                        pizza = new HamPizza();
                        break;
                    default:
                        break;
                }
                return pizza;
            }
        }

        public class PizzaStore
        {
            SimplePizzaFactory Factory;

            public PizzaStore(SimplePizzaFactory factory)
            {
                this.Factory = factory;
            }

            public Pizza OrderPizza(PizzaType type)
            {
                Pizza pizza = this.Factory.CreatePizza(type);

                pizza.Prepare();
                pizza.Bake();
                pizza.Cut();
                pizza.Box();
                return pizza;
            }
        }
    }
}
