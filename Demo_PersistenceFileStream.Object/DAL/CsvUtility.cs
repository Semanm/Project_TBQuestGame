using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Demo_PersistenceFileStream
{
    class CsvUtility
    {
        private static List<HighScore> highScoresClassListWrite = new List<HighScore>();
        private static List<string> highScoresStringListRead = new List<string>();
        private static List<HighScore> highScoresClassListRead = new List<HighScore>();
        private static List<HighScore> highScoresClassList = new List<HighScore>();
        private static List<string> highScoresStringListWrite = new List<string>();
        private static List<string> highScoresStringList = new List<string>();
        
        private static string userInput;
        private static int counter = 0;
        private static string textFilePath = "Data\\Data.txt";

        #region Menu Methods 
        
        public static void DisplayMainMenu()
        {
            Console.WriteLine("\n Welcome to File Transfer 3000");
            Console.WriteLine(" Please choose from the following options \n\n");
            Console.WriteLine("  A: Display all records.");
            Console.WriteLine("  B: Add a record.");
            Console.WriteLine("  C: Delete a record.");
            Console.WriteLine("  D: Update a record");
            Console.WriteLine("  E: Clear all records.");
            Console.WriteLine("  F: Read File");
            Console.WriteLine("  G: Exit. \n\n");

            Console.Write("  Input: ");
            string userInput = Console.ReadLine().ToUpper();
            while (true)
            {
                switch (userInput)
                {
                    case "A":
                        DisplayScores();
                        break;
                    case "B":
                        AddRecord();
                        break;
                    case "C":
                        DeleteRecord();
                        break;
                    case "D":
                        UpdateRecord();
                        break;
                    case "E":
                        ClearAllRecords();
                        break;
                    case "F":
                        ReadFile(0);
                        break;

                    case "G":
                        Exit();
                        break;

                    default:
                        Console.Write("\n oops, that wasn't an option: ");
                        userInput = Console.ReadLine().ToUpper();
                        break;

                }
            }
        }

        private static void ContinueToMainMenu()
        {
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void DisplayScores()
        {
            Console.Clear();
            ObjectListRead(textFilePath);
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void AddRecord()
        {
            Console.Clear();
            ObjectListWrite(textFilePath);
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void DeleteRecord()
        {
            Console.Clear();
            ObjectListDeleteRecord(textFilePath);
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void UpdateRecord()
        {
            Console.Clear();
            ObjectListUpdateRecord(textFilePath);
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void ClearAllRecords()
        {
            Console.Clear();
            ObjectListClearAll(textFilePath);
            Console.WriteLine("\n Press any key to continue \n");
            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void Exit()
        {
            DisplayClosingScreen();
            Console.Clear();
            DisplayMainMenu();
        }

        #endregion

        #region Methods


        private static void UserInputEqualsNull(string dataFile)
        {
            if (userInput == null)
            {
                if (highScoresClassList.Count > 0)
                {
                    Console.Write("\n Enter a name to change from the list: ");
                    string userToChange = Console.ReadLine();

                    foreach (var player in highScoresClassList)
                    {

                        ValidatePlayerName(userToChange);

                        Console.Write("\n Change player name to: ");
                        string newPlayer = Console.ReadLine();


                        Console.Write("\n Change player score to: ");
                        int newScore = UserScoreValidation();

                        highScoresClassList.Add(new HighScore() { PlayerName = newPlayer, PlayerScore = newScore });
                        break;
                    }
                }

                else
                {
                    userInput = null;
                }
            }
        }

        private static void NoPlayersToChange(string dataFile)
        {
            if (counter == 0)
            {
                InitializeScores(dataFile);
                counter++;
            }
            else
            {
                if (highScoresClassList.Count > 0)
                {
                    InitializedAlready(dataFile);
                }
                else
                {
                    Console.WriteLine("\n You have no players to change.");
                    Console.WriteLine("\n Would you like to add a new player?");
                    Console.Write("\n Yes or No?");
                    userInput = Console.ReadLine().ToLower();

                    switch (userInput)
                    {
                        case "no":
                            break;

                        case "yes":
                            ObjectListWrite(dataFile);
                            counter++;
                            break;

                        default:
                            break;
                    }
                }
            }

        }

        private static int UserScoreValidation()
        {
            int newScore;
            int userScore;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out userScore))
                {
                    newScore = userScore;
                    return newScore;
                }
                else
                    Console.Write("\n Sorry, please enter a number: ");
            }
        }

        private static bool UserNameValidation(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        private static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("\n\n Thank you for using FIle Manager 3000");
            Console.WriteLine("\n Are you sure you would like to exit?");
            Console.Write("\n Yes or No?");
            userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "no":
                    break;

                case "yes":
                    Console.WriteLine("\n Press any key to exit.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    counter++;
                    break;

                default:
                    break;
            }

        }
     
        private static void ValidatePlayerName(string Name)
        {
            string name = Name;
           
            foreach (var player in highScoresClassList)
            {
                if (string.Compare(name, player.PlayerName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    highScoresClassList.Remove(player);
                    break;

                }  
            }                  
                
        }

        private static void InitializeScores(string dataFile)
        {
            highScoresClassListWrite = InitializeListOfHighScores();
            WriteHighScoresToTextFile(highScoresClassListWrite, dataFile);
            Console.WriteLine("\n  High Scores \n");
            highScoresClassListRead = ReadHighScoresFromTextFile(dataFile);
            DisplayHighScores(highScoresClassListRead);
        }

        private static void InitializedAlready(string dataFile)
        {
            WriteHighScoresToTextFile(highScoresClassListWrite, dataFile);
            Console.WriteLine("\n  High Scores \n");
            highScoresClassListRead = ReadHighScoresFromTextFile(dataFile);
            DisplayHighScores(highScoresClassListRead);
        }

        private static void ObjectListClearAll(string dataFile)
        {
            Console.WriteLine("\n Are you sure you want to clear all records?");
            Console.Write("\n Yes or No?");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "no":
                    break;

                case "yes":
                    highScoresClassList.Clear();
                    counter++;
                    break;

                default:
                    break;
            }

        }

        private static void ObjectListUpdateRecord(string dataFile)
        {
            NoPlayersToChange(dataFile);

            UserInputEqualsNull(dataFile);
        }

        private static void ObjectListDeleteRecord(string dataFile)
        {
            if (counter == 0)
            {
                 InitializeScores(dataFile);
                 counter++;
            }
            else
            {
                if(highScoresClassList.Count > 0)
                {
                    InitializedAlready(dataFile);
                    Console.Write("\n Enter a name to delete from the list: ");
                    string userToDelete = Console.ReadLine();

                    foreach (var player in highScoresClassList)
                    {
                        ValidatePlayerName(userToDelete);
                        break;
                    }
                }
                else
                    Console.WriteLine("\n Sorry, you have no high scores entered \n");                               
            }   
        }

        private static void ObjectListWrite(string dataFile)
        {
            string userAddedHighScore_Name;
            int userAddedHighScore_Score;

            if (counter == 0)
            {
                InitializeScores(dataFile);
                counter++;
            }
            else
            {
                if (highScoresClassList.Count > 0)
                {
                    InitializedAlready(dataFile);
                }
                else
                    Console.WriteLine("\n Add a player \n");
            }

            Console.Write("\n Enter player name: ");
            userAddedHighScore_Name = Console.ReadLine();
            while (true)
            {
                if (!UserNameValidation(userAddedHighScore_Name))
                {
                    Console.Write("\n Player Names can only be letters: ");
                    userAddedHighScore_Name = Console.ReadLine();
                    UserNameValidation(userAddedHighScore_Name);
                }
                else
                {
                    break;
                }
            }
          
            Console.Write("\n Enter player score: ");
            userAddedHighScore_Score = UserScoreValidation();


            highScoresClassList.Add(new HighScore { PlayerName = userAddedHighScore_Name, PlayerScore = userAddedHighScore_Score });
            counter++; 
            DisplayHighScores(highScoresClassListWrite);
            WriteHighScoresToTextFile(highScoresClassListWrite, dataFile);
            WriteHighScoresToTextFile(highScoresClassListWrite, dataFile);  
            Console.WriteLine("\n High score has been saved successfully.\n");                 
        }

        private static void ObjectListRead(string dataFile)
        {
            if (counter == 0)
            {
                InitializeScores(dataFile);
                counter++;       
            }
            else
            {
                if (highScoresClassList.Count > 0)
                {
                    InitializedAlready(dataFile);
                }
                else
                    Console.WriteLine("\n Sorry, you have no high scores entered \n");
            }                                         
        }

        private static List<HighScore> InitializeListOfHighScores()
        {
            highScoresClassList.Add(new HighScore() { PlayerName = "Mike", PlayerScore = 1296 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Joe", PlayerScore = 345 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Sue", PlayerScore = 867 });
            highScoresClassList.Add(new HighScore() { PlayerName = "Emily", PlayerScore = 2309 });

            return highScoresClassList;
        }

        private static void DisplayHighScores(List<HighScore> highScoreClassList)
        {
            foreach (HighScore player in highScoreClassList)
            {
                Console.WriteLine(" Player: {0} -- Score: {1}", player.PlayerName, player.PlayerScore);
            }
        }

        private static void WriteHighScoresToTextFile(List<HighScore> highScoreClassLIst, string dataFile)
        {
            string highScoreString;

            // build the list to write to the text file line by line
            foreach (var player in highScoreClassLIst)
            {
                highScoreString = player.PlayerName + "," + player.PlayerScore;
                highScoresStringListWrite.Add(highScoreString);
            }

            File.WriteAllLines(dataFile, highScoresStringListWrite);
        }

        private static List<HighScore> ReadHighScoresFromTextFile(string dataFile)
        {
            const char delineator = ',';   
            // read each line and put it into an array and convert the array to a list
            highScoresStringList = File.ReadAllLines(dataFile).ToList();

            foreach (string highScoreString in highScoresStringList)
            {
                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = highScoreString.Split(delineator);                
            }

            return highScoresClassList;
        }

        private static void ReadFile(int i)
        {
            
            System.IO.StreamReader file = new System.IO.StreamReader(textFilePath);
            char[] buffer = new char[100];
            try
            {
                file.ReadBlock(buffer, i, buffer.Length);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}", textFilePath, e.Message);
            }

            finally
            {
                if (file != null)
                {
                    string data = file.ReadLine().ToString();
                    Console.Clear();
                    Console.WriteLine(data);
                    Console.ReadKey();
                }
            }
        }

        #endregion
    }
}
