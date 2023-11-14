using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelOtherStart : PanelBase
{
    protected override void Start()
    {
        base.Start();

        transform.FindSonSonSon("ImgStart").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgMapEditor").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnStart":
                Hot.MgrUI_.HidePanel(false, gameObject, "PanelOtherStart");
                Hot.MgrUI_.ShowPanel<PanelGameArchiveChoose>(false, "PanelGameArchiveChoose");
                break;
            case "BtnMapEditor":
                Hot.MgrUI_.ShowPanel<PanelOtherMapEditor>(true, "PanelOtherMapEditor");
                break;
        }
    }    
}
