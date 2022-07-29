using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayer : MonoBehaviour
{
    [MenuItem("Build/Build WebGL")]
    public static void MyBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity"};
        buildPlayerOptions.locationPathName = GetBuildPath();
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
    
    [MenuItem("Build/Path Build WebGL")]
     private static string GetBuildPath()
    {
    	string targetPath = "WebGLBuild";
        string projectFolder = System.IO.Path.GetDirectoryName(Application.dataPath);
        string parentDir = System.IO.Directory.GetParent(projectFolder).FullName.ToString();
        projectFolder = System.IO.Path.Combine(parentDir, targetPath);
        projectFolder = System.IO.Path.Combine(projectFolder, "Build");

        Debug.Log(projectFolder);

        return projectFolder;
    }
}
