using System;
using System.Collections.Generic;
using System.Text;
using Organizer.FileWorker;

namespace Organizer
{
    internal class Helper
    {

        public static int ReadCommandsInt() => Convert.ToInt32(Console.ReadLine());
    }
    class ReadFile
    {
        internal List<String> filesLines;
        internal ReadFile()
        {
            filesLines = new List<String>();
        }
        internal void addLineToList(String str)
        {
            filesLines.Add(str);
        }

        internal void getListOfLinesFromFile()
        {
            foreach (string i in filesLines)
            {
                Console.WriteLine(i);
            }
        }

        internal int getCountOfList() => filesLines.Count;


    }


    internal class OrganizerMenu
    {
        int programKey;
        public OrganizerMenu()
        {
            Console.WriteLine("Hello, you open Orginezer!\n" + "If you want to start, please enter 1. If you want to exit please enter 0");

            StartMenu(Helper.ReadCommandsInt());
        }
        public void StartMenu(int programKey)
        {

            if (programKey == 1)
            {
                Console.Clear();

                Console.WriteLine("The organizer has the next functions:\n" + "1. Notes\n" +
                    "2. Open calculator\n" + "3. Wheather\n" + "3. To do\n" + "Please make your choose.");

                switch (Helper.ReadCommandsInt())
                {
                    case 1: NotesMenu(); break;
                    case 2: OpenCalculator(); break;
                    default:
                        Console.WriteLine("Unknown command"); break;


                }

            }
            else if (programKey == 0)
            { Environment.Exit(0); }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }
        public void OpenCalculator()
        {
        }
        public void NotesMenu()
        {
            Console.Clear();
            FilesStreams fw = new FilesStreams(@"C:\SomeDir\hta2.txt");
            Console.WriteLine("The organizer has the next functions:\n" + "1. Write text to file\n" + "2. Read from file\n"
                + "3. Go to main menu\n"
                + "Please make your choose.");


            switch (Helper.ReadCommandsInt())
            {
                case 1:
                    {

                        fw.AddTextToFile();
                        Console.Clear();
                        NotesMenu();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        fw.GetTextFromFileAsync();
                        Console.WriteLine("\nAre you want exit to previous menu? Type anyone or End for exit from program");

                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.End)
                        { Environment.Exit(0); }
                        else { Console.Clear(); NotesMenu(); }
                        break;
                    }
                case 3: StartMenu(1); break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }


        }


    }

}


