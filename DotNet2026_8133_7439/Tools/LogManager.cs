using System;
using System.Globalization;
using System.IO;

namespace Tools;

public static class LogManager
{
    private const string Log = "Log";
public static void LogMessage(string projectName, string funcName, string message)
{
    string filePath = GetCurrentFilePath();

    File.WriteAllText(
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt"),
        filePath);

    string directoryPath = GetCurrentDirectoryPath();
    Directory.CreateDirectory(directoryPath);

    if (!File.Exists(filePath))
    {
        File.Create(filePath).Close();
    }

    string logEntry =
        $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{projectName}.{funcName}:\t{message}";

    File.AppendAllText(filePath, logEntry + Environment.NewLine);
}
//     public static void LogMessage(string projectName, string funcName, string message)
//     {
//         ////
// System.Windows.Forms.MessageBox.Show("LogMessage called");
//         string directoryPath = GetCurrentDirectoryPath();
//         Directory.CreateDirectory(directoryPath);
//         ////
// System.Diagnostics.Debug.WriteLine(LogManager.GetCurrentFilePath());        string filePath = GetCurrentFilePath();
//         if (!File.Exists(filePath))
//         {
//             File.Create(filePath).Close();
//         }

//         string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{projectName}.{funcName}:\t{message}";
//         File.AppendAllText(filePath, logEntry + Environment.NewLine);
//     }

    public static string GetCurrentDirectoryPath()
    {
        string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Log);
        string monthDirectory = DateTime.Now.ToString("yyyy-MM", CultureInfo.InvariantCulture);
        return Path.Combine(root, monthDirectory);
    }

    public static string GetCurrentFilePath()
    {
        string directory = GetCurrentDirectoryPath();
        string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
        return Path.Combine(directory, fileName);
    }

    public static void CleanOldLogs()
    {
        string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Log);
        if (!Directory.Exists(root))
            return;

        DateTime now = DateTime.Now;
        foreach (var directory in Directory.GetDirectories(root))
        {
            string folderName = Path.GetFileName(directory);
            if (!DateTime.TryParseExact(folderName + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var folderDate))
                continue;

            int monthDifference = (now.Year - folderDate.Year) * 12 + (now.Month - folderDate.Month);
            if (monthDifference > 1)
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch
                {
                    // אם לא ניתן למחוק, נמשיך הלאה
                }
            }
        }
    }
}
