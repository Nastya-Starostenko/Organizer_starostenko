using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using Organizer;

namespace Organizer.FileWorker

{
  
        internal class FilesStreams
        {

            public string writePath;
            ReadFile notices;


            public FilesStreams(string filePath)
            {
                ChangePathToFile(filePath);
                ReadFile notices = new ReadFile();

            }

            public void ChangePathToFile(string filePath)
            {
                writePath = filePath; // @"C:\SomeDir\hta2.txt";
                int position = filePath.LastIndexOf(@"\");


                string directoryPath = filePath.Substring(position + 1); //@"C:\SomeDir";

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

            }

            public void AddTextToFile()
            {
               
                         try
                         {
                             bool replace = true;
                                AddFilesFromFileTolist();
                             if (notices.getCountOfList() != 0)
                             {
                                 Console.WriteLine("You have data in a file. Are you want replace or only add string to file? 1 - replace, 2 - only add");
                                 replace = Helper.ReadCommandsInt() == 1 ? false : true;
                             }


                             Console.WriteLine("When you finish, please type key END");
                             using (StreamWriter sw = new StreamWriter(writePath, replace, System.Text.Encoding.Default))
                             {
                                 ConsoleKeyInfo keyInfo;
                                 do
                                 {
                                     sw.WriteLine(Console.ReadLine());
                                     keyInfo = Console.ReadKey(true);
                                 } while (keyInfo.Key != ConsoleKey.End);

                                Console.WriteLine("You data was added to the file");
                        //add wait
                             }
                         }
                         catch (Exception e)
                         {
                             Console.WriteLine(e.Message);
                         }
                    
            }

            public void AddFilesFromFileTolist()
            {
                try
                {
                    string fileLine;
                    notices = new ReadFile();
                    using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.UTF8))
                    {
                        {
                            notices = new ReadFile();
                            while ((fileLine = sr.ReadLine()) != null)
                            {
                                notices.addLineToList(fileLine);
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            public void GetTextFromFileAsync()
            {
                try
                {
                    AddFilesFromFileTolist();
                    notices.getListOfLinesFromFile(); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


    
    }

