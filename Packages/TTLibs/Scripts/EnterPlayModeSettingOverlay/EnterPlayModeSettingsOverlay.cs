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

        public const string NONE_TEXT = "�h���C�����V�[�� �����[�h";
        public const string DISABLE_DOMAIN_RELOAD_TEXT = "�V�[�� �����[�h�̂�";
        public const string DISABLE_SCENE_RELOAD_TEXT = "�h���C�� �����[�h�̂�";
        public const string ALL_TEXT = "�S�Ė���";


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
            // EditorSettings.enterPlayModeOptions�̒l�ɂ���ă{�^���̃e�L�X�g��ύX����
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
