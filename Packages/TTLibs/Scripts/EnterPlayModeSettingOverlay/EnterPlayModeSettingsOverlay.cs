using UnityEngine;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.Toolbars;
using UnityEditor.UIElements;
using UnityEngine.PlayerLoop;

[Overlay(typeof(SceneView), "Enter PlayMode Settings")]
public class EnterPlayModeSettingsOverlay : ToolbarOverlay
{
    EnterPlayModeSettingsOverlay() : base(EnterPlayModeSettingButton.ID)
    {

    }

    [EditorToolbarElement(ID, typeof(SceneView))]
    public class EnterPlayModeSettingButton : ToolbarButton
    {
        public const string ID = "EnterPlayModeSettings";

        public const string NONE_TEXT = "ドメイン＆シーン リロード";
        public const string DISABLE_DOMAIN_RELOAD_TEXT = "シーン リロードのみ";
        public const string DISABLE_SCENE_RELOAD_TEXT = "ドメイン リロードのみ";
        public const string ALL_TEXT = "全て無効";


        public EnterPlayModeSettingButton()
        {
            text = GetButtonText();

            clicked += () =>
            {

                if (EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.None)
                {
                    EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableDomainReload;
                }
                else if (EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.DisableDomainReload)
                {
                    EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableSceneReload;
                }
                else if(EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.DisableSceneReload)
                {
                    EditorSettings.enterPlayModeOptions = (EnterPlayModeOptions.DisableSceneReload | EnterPlayModeOptions.DisableDomainReload);
                }
                else if (EditorSettings.enterPlayModeOptions ==
                    (EnterPlayModeOptions.DisableSceneReload | EnterPlayModeOptions.DisableDomainReload))
                {
                    EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.None;
                }

                text = GetButtonText();
            };
        }

        public static string GetButtonText()
        {
            string text = "";
            // EditorSettings.enterPlayModeOptionsの値によってボタンのテキストを変更する
            if (EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.None)
            {
                text = NONE_TEXT;
            }
            else if (EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.DisableDomainReload)
            {
                text = DISABLE_DOMAIN_RELOAD_TEXT;
            }
            else if (EditorSettings.enterPlayModeOptions == EnterPlayModeOptions.DisableSceneReload)
            {
                text = DISABLE_SCENE_RELOAD_TEXT;
            }
            else if (EditorSettings.enterPlayModeOptions ==
                (EnterPlayModeOptions.DisableSceneReload | EnterPlayModeOptions.DisableDomainReload))
            {
                text = ALL_TEXT;
            }
            return text;
        }
    }
}
