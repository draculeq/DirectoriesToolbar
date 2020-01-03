using UnityEditor;
using UnityEngine;

namespace Deadbit.DirectoriesToolbar
{
    public class DirectoriesToolbar
    {
        [MenuItem("Tools/Directories/Project")]
        public static void OpenProjectFolder()
        {
            OpenDirectory(Application.dataPath.Replace(@"/", @"\") + @"\..\");
        }

        [MenuItem("Tools/Directories/Output Log")]
        public static void OpenLogFolder()
        {
            OpenDirectory(AddAppDataPath(string.Format(@"LocalLow\{0}\{1}\output_log.txt", Application.companyName, Application.productName)), true);
        }

        [MenuItem("Tools/Directories/Crashes")]
        public static void OpenCrashesFolder()
        {
            OpenDirectory(AddAppDataPath(string.Format(@"Local\Temp\{0}\{1}\Crashes", Application.companyName, Application.productName)));
        }

        [MenuItem("Tools/Directories/Crash Dumps")]
        public static void OpenCrashDumpsFolder()
        {
            OpenDirectory(AddAppDataPath(@"Local\CrashDumps\"));
        }

        [MenuItem("Tools/Directories/Editor Log")]
        public static void OpenEditorLogFolder()
        {
            OpenDirectory(AddAppDataPath(@"Local\Unity\Editor\Editor.log"), true);
        }

        private static string AddAppDataPath(string path)
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\..\" + path;
        }

        private static void OpenDirectory(string path, bool select = false)
        {
            Debug.Log("Opening directory: " + path);
            System.Diagnostics.Process.Start("explorer.exe", (select ? "/select, " : "") + path);
        }
    }
}