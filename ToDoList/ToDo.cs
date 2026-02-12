using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    public enum MenuOption
    { See,Add,Remove,Exit,Invalid}
    public class ToDo
    {
        private readonly List<string> toDoList = new List<string>();
        #region RunApp
        public void RunApp()
        {
            bool run = true;
            while (run)
            {
                ShowMenu();

                MenuOption option = ReadOption();

               
                switch (option)
                {
                    case MenuOption.See:
                        SeeAllToDos();
                        break;
                    case MenuOption.Add:
                        AddAToDo();
                        break;
                    case MenuOption.Remove:
                        RemoveAToDo();
                        break;
                    case MenuOption.Exit:
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
        private MenuOption ReadOption()
        {
            string? input = Console.ReadLine()?.ToLower(); 
            return input switch
            { "s" => MenuOption.See,
                "a" => MenuOption.Add,
                "r" => MenuOption.Remove,
                "e" => MenuOption.Exit,
                _ => MenuOption.Invalid
            };
        }

        #endregion
        #region SeeAllToDos
        private void SeeAllToDos()
        {
            if (!toDoList.Any())
            {
                Console.WriteLine("No TODOs have been added yet");
            }

            else
            {
                for (int i = 0; i < toDoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{toDoList[i]}");
                }


            }
        }
        #endregion
        #region AddAToDo
        private void AddAToDo()
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
        private void RemoveAToDo()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Select the index of the TODO you want to remove:");


                if (toDoList.Count == 0)
                {
                    Console.WriteLine("No TODOs have been added yet");
                    flag = false;
                }
                else
                {
                    SeeAllToDos();
                }

                string? index = Console.ReadLine();
                if (string.IsNullOrEmpty(index))
                {
                    Console.WriteLine("Selected index cannot be empty");
                }

                else if (!int.TryParse(index, out int indexInt) || indexInt < 1 || indexInt > toDoList.Count)
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
        private void ShowMenu()
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
