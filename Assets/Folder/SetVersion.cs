using UnityEditor;
using System.Linq;

public class SetVersion
{
    public static void ApplyVersion()
    {
        string[] args = System.Environment.GetCommandLineArgs();

        string versionArg = args.FirstOrDefault(arg => arg.StartsWith("-version="));
        if (versionArg != null)
        {
            string version = versionArg.Split('=')[1];
            PlayerSettings.bundleVersion = version;
            Debug.Log($"Set bundle version to: {version}");

            // Optional: Set specific version settings for different platforms
            // For example, for Windows Store Apps (UWP):
            Version newVersion = new Version(version);
            PlayerSettings.WSA.packageVersion = newVersion;
        }
    }
}
