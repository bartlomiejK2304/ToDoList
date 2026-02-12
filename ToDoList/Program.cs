namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> toDoList = new List<string>();
            RunApp(toDoList);
        }
        #region RunApp
        static void RunApp(List<string> toDoList)
        {
            bool run = true;
            while (run)
            {
                ShowMenu();
                string? answer = Console.ReadLine();
                answer = answer?.ToLower();

                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
                switch (answer)
                {
                    case "s":
                        SeeAllToDos(toDoList);
                        break;
                    case "a":
                        AddAToDo(toDoList);
                        break;
                    case "r":
                        RemoveAToDo(toDoList);
                        break;
                    case "e":
                        run = false;
                        Console.WriteLine("Goodbye!!!");
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
            Console.ReadKey();



        }


        #endregion
        #region SeeAllToDos
       static void SeeAllToDos(List<string> toDoList)
            {
                if(!toDoList.Any())
                {
                    Console.WriteLine("No TODOs have been added yet");
                }

                else
                {
                    for(int i = 0;i<toDoList.Count;i++)
                    {
                        Console.WriteLine($"{i + 1}.{toDoList[i]}");
                    }


                }

               


            }
            #endregion
            #region AddAToDo
           static void AddAToDo(List<string> toDoList)
            {
                bool run = true;


                while (run)
                {
                    Console.WriteLine("Enter the TODO description:");
                    string? answer = Console.ReadLine();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine("The description cannot be empty");
                    }

                    else if (toDoList.Any(a => a == answer))
                    {
                        Console.WriteLine("The description must be unique");
                    }

                    else
                    {
                        Console.WriteLine($"TODO successfully added:{answer}");
                        toDoList.Add(answer);
                        run = false;

                    }
                }
            }
            #endregion
            #region RemoveToDo
           static void RemoveAToDo(List<string> toDoList)
            {

                bool flag = true;



                while(flag)
                {
                    Console.WriteLine("Select the index of the TODO you want to remove:");
                  

                    if(toDoList.Count ==0)
                    {
                        Console.WriteLine("No TODOs have been added yet");
                        flag = false;
                    }
                    else
                    {
                        SeeAllToDos(toDoList);
                    }

                    string ?index = Console.ReadLine();
                      if (string.IsNullOrEmpty(index))
                    {
                        Console.WriteLine("Selected index cannot be empty");
                    }

                    else if (!int.TryParse(index, out int indexInt) || indexInt<1|| indexInt>toDoList.Count)
                    {
                        Console.WriteLine("The given index is not valid.");
                        continue;
                    }

                    else
                    {
                        string removed = toDoList[indexInt - 1];
                        toDoList.RemoveAt(indexInt - 1);
                        Console.WriteLine($"TODO removed : {removed}");
                        flag = false;
                    }

                }
            }
            #endregion
            #region ShowMenu
          static  void ShowMenu()
            {
                Console.WriteLine("Hello!");
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("[S]ee all TODO's");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

            }
            #endregion
    }
}
