using System;
using UnityEngine;
using UnityEditor;

public class SetVersion
{
    [MenuItem("Tools/Set Version")]
    public static void SetGameVersion()
    {
        string major = Environment.GetEnvironmentVariable("MAJOR_VERSION");
        string minor = Environment.GetEnvironmentVariable("MINOR_VERSION");
        string patch = Environment.GetEnvironmentVariable("PATCH_VERSION");

        if (major != null && minor != null && patch != null)
        {
            Version version = new Version(int.Parse(major), int.Parse(minor), int.Parse(patch));
            PlayerSettings.bundleVersion = version.ToString();
            Debug.Log($"Set version to {version}");
        }
        else
        {
            Debug.LogError("Could not set version, environment variables not found");
        }
    }
}
