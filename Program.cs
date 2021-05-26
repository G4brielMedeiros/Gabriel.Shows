using System;

namespace Project.Shows
{
    class Program
    {
        static ShowsRepository repo = new ShowsRepository();

        static void Main(string[] args)
        {
            string UserInput = GetUserInput();

            while (true)
            {
                switch(UserInput)
                {

                    case "1":           //list
                        DisplayShows();
                        break;
                    
                    case "2":           //insert
                        InsertShow("insert");
                        break;
                    
                    case "3":           //update
                        InsertShow("update");
                        break;
                    
                    case "4":           //delete
                        DeleteShow();
                        break;
                    
                    case "5":           //details
                        ViewShowDetails();
                        break;
                    
                    case "C":           //clear
                        Console.Clear();
                        break;
                    
                    case "X":           //exit
                        WriteLine("Goodbye!");
                        return;
                        

                    default:
                        InvalidInput();
                        break;
                }

                UserInput = GetUserInput();
            }
        }


        //HELPER FUNCTION: calls Console.WriteLine()
        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }


        //HELPER FUNCTION: Gets show details from user
        private static void GetShowDetails(out int chosenGenre, out string chosenTitle, out int chosenYear, out string chosenDescription)
        {
            Console.Write("Enter a genre from the options above: ");
            chosenGenre = int.Parse(Console.ReadLine());

            if(!Enum.IsDefined(typeof(Genre), chosenGenre))
            {
                throw new Exception();
            }
                    
            Console.Write("Enter the title: ");
            chosenTitle = Console.ReadLine();

            Console.Write("Enter the launch year: ");
            chosenYear = int.Parse(Console.ReadLine());

            Console.Write("Enter the description: ");
            chosenDescription = Console.ReadLine();
        }


        //HELPER FUNCTION: Warns user of invalid input
        private static void InvalidInput()
        {
            WriteLine("\n\nERROR: Invalid input. Operation failed.");
        }


        //HELPER FUNCTION: Lists all genres
        private static void DisplayGenres()
        {
            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
        }




        //MAIN FUNCTIONS:


        //Displays interface and gets user input 
        private static string GetUserInput()
        {
            WriteLine("");
            WriteLine("Gabriel Shows at your service!!");
            WriteLine("Select option:");
            WriteLine("1- List series");
            WriteLine("2- Insert new series");
            WriteLine("3- Update existing series");
            WriteLine("4- Delete series");
            WriteLine("5- View series");
            WriteLine("C- Clean console");
            WriteLine("X= Exit");
            WriteLine("");

            string UserInput = Console.ReadLine().ToUpper();
            WriteLine("");
            return UserInput;
        }


        //Lists shows by [id: = title]
        private static void DisplayShows()
        {
            WriteLine("Listing shows...");

            var showList = repo.List();

            if(showList.Count == 0)
            {
                WriteLine("No series found.");
                return;
            }

            foreach (var show in showList)
            {
                Console.WriteLine("#ID {0}: - {1} {2}", show.id, show.title, show.deleted == true ? "*DELETED*" : "");            
            }
        }


        //Asks user to insert/update a show
        private static void InsertShow(string operation)
        {
            var chosenId = -1;

            if (operation == "update")
            {
                WriteLine("Enter the ID: ");
                chosenId = int.Parse(Console.ReadLine());
            }
            else chosenId = repo.NextId();
     
            DisplayGenres();

            try
            {
                GetShowDetails(out var chosenGenre, out var chosenTitle, out var chosenYear, out var chosenDescription);

                var show = new Show
                    (     
                        id:             chosenId,
                        genre:          (Genre)chosenGenre,
                        title:          chosenTitle,
                        launchYear:           chosenYear,
                        description:    chosenDescription
                    );
                
                if (operation == "update")
                {
                    repo.UpdateById(chosenId, show);
                }
                else repo.Insert(show);
            }
            catch (System.Exception)
            {      
                InvalidInput();
            }          
        }


        //Asks user to delete a show
        private static void DeleteShow()
        {
            WriteLine("Enter the ID of the series to be deleted: ");
            repo.DeleteById(int.Parse(Console.ReadLine()));
        }


        //Lists details of show based on user input id
        private static void ViewShowDetails()
        {
            WriteLine("Enter series ID: ");
            Console.WriteLine(    repo.ReadById( int.Parse(Console.ReadLine()) )    );
        }


    } //END CLASS
} //END NAMESPACE
