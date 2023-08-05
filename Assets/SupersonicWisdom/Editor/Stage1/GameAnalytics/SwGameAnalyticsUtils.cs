#if SW_STAGE_STAGE1_OR_ABOVE
using GameAnalyticsSDK;
using UnityEditor;

namespace SupersonicWisdomSDK.Editor
{
    internal static class SwGameAnalyticsUtils
    {
        #region --- Private Methods ---

        internal static void VerifyMandatoryFlags()
        {
            if (UnityEditorInternal.InternalEditorUtility.isHumanControllingUs && (!GameAnalytics.SettingsGA.SubmitErrors || !GameAnalytics.SettingsGA.UsePlayerSettingsBuildNumber))
            {
                var shouldUpdate = SwEditorAlerts.AlertWarning(SwEditorConstants.UI.VERIFY_GA_SETTINGS, SwEditorConstants.UI.ButtonTitle.SetToTrueAndSave, SwEditorConstants.UI.ButtonTitle.Cancel);

                if (shouldUpdate)
                {
                    GameAnalytics.SettingsGA.SubmitErrors = true;
                    GameAnalytics.SettingsGA.UsePlayerSettingsBuildNumber = true;
                    EditorUtility.SetDirty(GameAnalytics.SettingsGA);
                    AssetDatabase.SaveAssets();
                }
            }
        }

        #endregion
    }
}
#endif