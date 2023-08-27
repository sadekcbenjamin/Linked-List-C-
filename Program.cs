using System;

namespace CityNavigator 
{
    public class CityNode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CityNode Next { get; set; }

        public CityNode(string name, string description) 
        {
            Name = name;
            Description = description;
            Next = null;
        }
    }

    public class TourPlanner
    {
        private CityNode head;
        int count = 0;

        public TourPlanner()
        {
            head = null;
        }

        // TODO: Implement the SearchCity, 
        // and DisplayTour methods here.
        public bool AddCity(string name, string description) 
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description)) 
            {
                Console.WriteLine("Invalid input");
                return false;
            }
            
            CityNode newNode = new CityNode(name, description);

            if (this.count == 0) 
            {
                this.head = newNode;
                Console.WriteLine("City Added: " + name + " - " + description);
                this.count++;
                return true;
            }
            else
            {
                CityNode curr = this.head;
                while(curr.Next != null) 
                {
                    curr = curr.Next;
                }
                curr.Next = newNode;
                this.count++;
                Console.WriteLine("City Added: " + name + " - " + description);
                return true;
            }
        }

        public bool InsertCity(CityNode cityToInsert, int position) //zero indexed
        {
            if (cityToInsert == null) 
            {
                Console.WriteLine("City does not exist...");
                return false;
            }

            if (position < 0 || position > count + 1) 
            {
                Console.WriteLine("Invalid index...");
                return false;
            }
            else 
            {
                if (position == 0 )
                {
                    cityToInsert.Next = this.head;
                    this.head = cityToInsert;
                    count++;
                    Console.WriteLine("City Inserted at position " + position + ": " + cityToInsert.Name + " - " + cityToInsert.Description);
                    return true;
                }
                else 
                {
                    CityNode prev = this.head;
                    CityNode curr = this.head.Next;
                    int i = 0;
                    while ( curr.Next != null && i <  position - 1)
                    {
                        prev = curr;
                        curr = curr.Next;
                        i++;
                    }
                    
                    prev.Next = cityToInsert;
                    cityToInsert.Next = curr;
                    count++;
                    Console.WriteLine("City Inserted at position " + position + ": " + cityToInsert.Name + " - " + cityToInsert.Description);
                    return true;
                }
            }
        }

        public bool DeleteCity(string cityName)
        {
            if (this.count == 0) 
            {
                Console.WriteLine("This list is empty...No cities to delete");
                return false;
            }

            if (this.head.Name == cityName)
            {
                this.head = this.head.Next;
                Console.WriteLine("City Deleted: " + cityName);
                return true;
            }

            CityNode prev = this.head;
            CityNode curr = prev.Next;
            while(curr != null) 
            {
                if (curr.Name == cityName)
                {
                    prev.Next = curr.Next;
                    curr.Next = null;
                    count--;
                    Console.WriteLine("City Deleted: " + cityName);
                    return true;
                }
                else
                {
                    prev = curr;
                    curr = curr.Next;
                }
            }
            Console.WriteLine("City Not Found: " + cityName);
            return false;
        }

        public bool SearchCity(string cityName)
            {
            if (this.count == 0) 
            {
                Console.WriteLine("This list is empty...No cities to search");
                return false;
            }

            if (this.head.Name == cityName)
            {
                Console.WriteLine("City " + cityName + " Found: " + head.Description);
                return true;
            }

            CityNode curr = this.head.Next;
            while(curr != null) 
            {
                if (curr.Name == cityName)
                {
                    Console.WriteLine("City " + cityName + " Found: " + curr.Description);
                    return true;
                }
                else
                    curr = curr.Next;
            }

            Console.WriteLine("City " + cityName + "  Not Found" );
            return false;
        }
        
        public void DisplayTour() {
            if (this.count == 0 || this.head == null) {
                Console.WriteLine("There are no cities to display");
                return;
            }

            CityNode curr = this.head;
            string displayString = "City List: ";
            while (curr != null) {
                if (curr.Next != null) {
                    displayString += curr.Name + " -> ";
                }
                else
                    displayString += curr.Name;
                     curr = curr.Next;
            }

            Console.WriteLine(displayString);
            return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TourPlanner planner = new TourPlanner();

            planner.AddCity("Seattle", "A seaport city on the West Coast of the U.S.");
            planner.AddCity("San Francisco", "Known for the Golden Gate Bridge.");
            CityNode node1 = new CityNode("Portland", "Known for its parks, bridges, and bicycle paths.");
            planner.AddCity("Pittsburgh", "A city known it's many bridges and Cathedral of Learning");
            planner.AddCity("Loveland", "A sleepy town in Northern Colorado, south of Ft Collins");
            planner.InsertCity(node1,1);
            planner.SearchCity("Seattle");
            planner.DisplayTour();
            planner.DeleteCity("Pittsburgh");
            planner.DeleteCity("Portland");
            planner.DisplayTour();
        }
    }
}