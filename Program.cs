using System;

namespace Gabriel.Shows
{
    class Program
    {
        static ShowsRepository showsRepo = new ShowsRepository();

        static void Main(string[] args)
        {
            WriteCommands();
            string UserInput = GetUserInput();

            while (true)
            {
                switch(UserInput)
                {

                    case "list":             //list
                        DisplayShows();
                        break;
                    
                    case "insert":           //insert
                        InsertShow("insert");
                        break;
                    
                    case "update":           //update
                        InsertShow("update");
                        break;
                    
                    case "delete":           //delete
                        DeleteShow();
                        break;
                    
                    case "view":             //details
                        ViewShowDetails();
                        break;
                    
                    case "clear":            //clear
                        Console.Clear();
                        WriteCommands();
                        break;

                    case "help":
                        WriteCommands();
                        break;
                    
                    case "exit":             //exit
                        WriteLine("Goodbye!");
                        return;
                        
                    default:
                        InvalidInput("Invalid command. try 'help'");
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
        private static void GetShowDetails(out int chosenGenre, out string chosenTitle, out int chosenYear, out string chosenDescription, out int chosenEpisodes)
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

            Console.Write("Enter episode count: ");
            chosenEpisodes = int.Parse(Console.ReadLine());
        }


        //HELPER FUNCTION: Warns user of invalid input
        private static void InvalidInput(string msg)
        {
            WriteLine("\n\nERROR: " + msg);
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


        //Gets user input 
        private static string GetUserInput()
        {
            string UserInput = Console.ReadLine().ToLower();
            WriteLine("");
            return UserInput;
        }

        private static void WriteCommands()
        {
            WriteLine("");
            WriteLine("GABRIEL SHOWS");
            WriteLine("COMMANDS:");
            WriteLine("list");
            WriteLine("insert");
            WriteLine("update");
            WriteLine("delete");
            WriteLine("view");
            WriteLine("clear");
            WriteLine("exit");
            WriteLine("");
        }


        //Lists shows by [id: = title]
        private static void DisplayShows()
        {
            WriteLine("Listing shows...");

            var showList = showsRepo.List();

            if(showList.Count == 0)
            {
                WriteLine("No shows found.");
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
            else chosenId = showsRepo.NextId();
     
            DisplayGenres();

            try
            {
                GetShowDetails(out var chosenGenre, out var chosenTitle, out var chosenYear, out var chosenDescription, out var chosenEpisodes);

                var show = new Show
                    (     
                        id:             chosenId,
                        genre:          (Genre)chosenGenre,
                        title:          chosenTitle,
                        launchYear:           chosenYear,
                        description:    chosenDescription,
                        episodes: chosenEpisodes
                    );
                
                if (operation == "update")
                {
                    showsRepo.UpdateById(chosenId, show);
                }
                else showsRepo.Insert(show);

                WriteLine("Show registered.");
            }
            catch (System.Exception)
            {      
                InvalidInput("Invalid parameters rejected.");
            }          
        }


        //Asks user to delete a show
        private static void DeleteShow()
        {
            WriteLine("Enter the ID of the show to be deleted: ");
            showsRepo.DeleteById(int.Parse(Console.ReadLine()));
        }


        //Lists details of show based on user input id
        private static void ViewShowDetails()
        {
            WriteLine("Enter show ID: ");
            Console.WriteLine(    showsRepo.ReadById( int.Parse(Console.ReadLine()) )    );
        }

    } //END CLASS
} //END NAMESPACE
