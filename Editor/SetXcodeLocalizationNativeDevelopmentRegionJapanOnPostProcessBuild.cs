using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace Kogane.Internal
{
    /// <summary>
    /// iOS ビルド完了時に Xcode プロジェクトの Localization native development region に Japan を設定するエディタ拡張
    /// </summary>
    internal static class SetXcodeLocalizationNativeDevelopmentRegionJapanOnPostProcessBuild
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// ビルド完了時に呼び出されます
        /// </summary>
        [PostProcessBuild]
        private static void OnPostProcessBuild
        (
            BuildTarget buildTarget,
            string      pathToBuiltProject
        )
        {
            if ( buildTarget != BuildTarget.iOS ) return;

            var path  = $"{pathToBuiltProject}/Info.plist";
            var plist = new PlistDocument();

            plist.ReadFromFile( path );
            var root = plist.root;
            root.SetString( "CFBundleDevelopmentRegion", "ja_JP" );
            plist.WriteToFile( path );
        }
    }
}