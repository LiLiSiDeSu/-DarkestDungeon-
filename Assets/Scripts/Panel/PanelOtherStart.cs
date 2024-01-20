using UnityEngine.UI;

public class PanelOtherStart : PanelBase
{
    protected override void Awake()
    {
        base.Awake();

        transform.FindSonSonSon("ImgStart").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgEditorMap").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnStart":
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelOtherStart");
                Hot.MgrUI_.ShowPanel<PanelGameArchiveChoose>(false, "PanelGameArchiveChoose");
                Hot.e_NowPlayerLocation = E_PlayerLocation.ChooseGameArchive;
                break;
            case "BtnEditorMap":
                Hot.MgrUI_.ShowPanel<PanelOtherEditorMiniMap>(true, "PanelOtherEditorMiniMap");
                break;
            case "BtnEditorRoleConfig":
                Hot.MgrUI_.ShowPanel<PanelOtherEditorRoleConfig>(true, "PanelOtherEditorRoleConfig");
                break;
        }
    }
}
