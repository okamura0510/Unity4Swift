using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
#if UNITY_IPHONE
using UnityEditor.iOS.Xcode;
#endif

namespace U4S
{
    public class Unity4SwiftPostProcessBuild
    {
        [PostProcessBuild(0)]
        public static void OnPostprocessBuild(BuildTarget target, string path)
        {
            if(target != BuildTarget.iOS) return;
            
            var projectPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
            var project     = new PBXProject();
            project.ReadFromFile(projectPath);
            
            var guid = project.TargetGuidByName("Unity-iPhone");
            project.SetBuildProperty(guid, "SWIFT_VERSION",                         "Swift 4.0");
            project.SetBuildProperty(guid, "SWIFT_OBJC_BRIDGING_HEADER",            "Libraries/Unity4Swift/Plugins/iOS/Unity-iPhone-Bridging-Header.h");
            project.SetBuildProperty(guid, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
            project.SetBuildProperty(guid, "LD_RUNPATH_SEARCH_PATHS",               "@executable_path/Frameworks");
            
            File.WriteAllText(projectPath, project.WriteToString());
        }
    }
}
