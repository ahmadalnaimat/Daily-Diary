using System;
using System.IO;

namespace DiaryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");
            DailyDiary diary = new DailyDiary(filepath);
            diary.Run();
        }
    }
}
