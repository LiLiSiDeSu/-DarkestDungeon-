using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PanelExpeditionMiniMap : PanelBase
{
    public Transform ExpeditionMiniMapContent;

    protected override void Awake()
    {
        base.Awake();

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyDown", (key) =>
        {
            if (Hot.e_NowPlayerLocation == E_PlayerLocation.OnExpedition && key == Hot.MgrInput_.ExpeditionMiniMap)
            {
                if (Hot.PoolNowPanel_.ListNowPanel.Contains("PanelExpeditionMiniMap"))
                    Hot.MgrUI_.HidePanel(false, Hot.PanelExpeditionMiniMap_.gameObject, "PanelExpeditionMiniMap");
                else
                    Hot.MgrUI_.ShowPanel<PanelExpeditionMiniMap>(true, "PanelExpeditionMiniMap");
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") && 
                key == Hot.MgrInput_.AddMapSize && ExpeditionMiniMapContent.localScale.x < 2f)
            {
                ExpeditionMiniMapContent.localScale += new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        Hot.CenterEvent_.AddEventListener<KeyCode>("KeyHold",
        (key) =>
        {
            if (Hot.PoolNowPanel_.ContainPanel("PanelExpeditionMiniMap") && 
                key == Hot.MgrInput_.ReduceMapSize && ExpeditionMiniMapContent.localScale.x > 1f)
            {
                ExpeditionMiniMapContent.localScale -= new Vector3(Hot.ValueChangeMapSize * Time.deltaTime, Hot.ValueChangeMapSize * Time.deltaTime, 0);
            }
        });

        ExpeditionMiniMapContent = transform.FindSonSonSon("ExpeditionMiniMapContent");
    }    
}