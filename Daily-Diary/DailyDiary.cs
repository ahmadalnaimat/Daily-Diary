using System;
using System.IO;
using System.Linq;

namespace DiaryManager
{
    public class DailyDiary
    {
        private static string _filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");

        public DailyDiary(string filePath)
        {
            _filePath = filePath;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Read Diary");
                Console.WriteLine("2. Add Entry");
                Console.WriteLine("3. Delete Entry");
                Console.WriteLine("4. Count Lines");
                Console.WriteLine("5. Search Entries");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ReadDiaryFile();
                        break;
                    case "2":
                        AddEntry();
                        break;
                    case "3":
                        DeleteEntry();
                        break;
                    case "4":
                        CountLines();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static string ReadDiaryFile()
        {
            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
            return File.ReadAllText(_filePath);
        }

        public void AddEntry()
        {
            Console.Write("Enter the date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Console.Write("Enter the content: ");
            string content = Console.ReadLine();

            Entry newEntry = new Entry { Date = date, Content = content };

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"{newEntry.Date} \n{newEntry.Content}");
            }

            Console.WriteLine("Entry added successfully.");
        }
        public void AddEntryTest(string testdate, string Testcont)
        {
            Console.Write("Enter the date (YYYY-MM-DD): ");
            Console.Write("Enter the content: ");

            Entry newEntry = new Entry { Date = testdate, Content = Testcont };

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"{newEntry.Date} \n{newEntry.Content}");
            }

            Console.WriteLine("Entry added successfully.");
        }
        public void DeleteEntry()
        {
            Console.Write("Enter the date of the entry to delete (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath).ToList();
                lines.RemoveAll(line => line.StartsWith(date));

                File.WriteAllLines(_filePath, lines);
                Console.WriteLine("Entry deleted successfully.");
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
        }

        public int CountLines()
        {
            int lineCount = 0;
            if (File.Exists(_filePath))
            {
                lineCount = File.ReadAllLines(_filePath).Length;
                Console.WriteLine($"Total number of lines: {lineCount}");
            }
            else
            {
                Console.WriteLine("Diary file not found.");
            }
            return lineCount;
        }
    }
}
