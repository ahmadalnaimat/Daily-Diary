using System;
using System.IO;
using Xunit;

namespace DiaryManager.Tests
{
    public class DailyDiaryTests : IDisposable
    {
        private readonly string _testFilePath = "test_diary.txt";
        private readonly DailyDiary _diary;

        public DailyDiaryTests()
        {
            CleanupTestFile();

            _diary = new DailyDiary(_testFilePath);
        }

        [Fact]
        public void ReadDiaryFile_ShouldReadContentFromFile()
        {
            // Arrange
            string[] testContent = { "2024-06-01", "First entry", "2024-06-02", "Second entry" };
            File.WriteAllLines(_testFilePath, testContent);

            // Act
            string result = DailyDiary.ReadDiaryFile();

            // Assert
            Assert.Contains("2024-06-01", result);
            Assert.Contains("First entry", result);
            Assert.Contains("2024-06-02", result);
            Assert.Contains("Second entry", result);
        }

        [Fact]
        public void AddEntry_ShouldIncreaseEntryCount()
        {
            // Arrange
            int initialLineCount = _diary.CountLines();

            // Act
            _diary.AddEntryTest("2024-06-29","hello Test");
            int newLineCount = _diary.CountLines();

            // Assert
            Assert.Equal(initialLineCount + 2, newLineCount);
        }

        public void Dispose()
        {
            CleanupTestFile();
        }

        private void CleanupTestFile()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}
