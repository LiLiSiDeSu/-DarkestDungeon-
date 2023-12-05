using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRolePortraitCanDrag : PanelBase, 
             IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image ImgRolePortraitCanDrag;

    public RectTransform RectRolePortraitCanDrag;
    public Transform RootExpeditionRole;    
    private Vector2 DragOffSet;

    public PanelCellRole PanelCellRole_;

    protected override void Awake()
    {
        base.Awake();

        PanelCellRole_ = transform.GetComponentInParent<PanelCellRole>();
        ImgRolePortraitCanDrag = transform.FindSonSonSon("ImgRolePortraitCanDrag").GetComponent<Image>();
        RectRolePortraitCanDrag = ImgRolePortraitCanDrag.GetComponent<RectTransform>();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortraitCanDrag":                
                Hot.PanelRoleDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index]);
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.NowRole = PanelCellRole_;
                    panel.BtnDismiss.SetActive(true);
                });
                break;
        }
    }    

    #region EventSystem�ӿ�ʵ��

    public void OnBeginDrag(PointerEventData eventData)
    {
        ImgRolePortraitCanDrag.raycastTarget = false;
        DragOffSet = new Vector2(transform.position.x, transform.position.y) - eventData.position;        

        RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
        transform.SetParent(Hot.MgrUI_.UIBaseCanvas, false);                     
        Hot.DragingRolePortrait = gameObject;        
    }

    public void OnDrag(PointerEventData eventData)
    {        
        transform.position = eventData.position + DragOffSet;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ImgRolePortraitCanDrag.raycastTarget = true;
        
        if (Hot.e_NowPointerLocation != E_NowPointerLocation.PanelTownExpeditionRole)
        {
            Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_RoleStatus = E_RoleStatus.None;
            Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition = -1;
            PanelCellRole_.ChangeRoleStatus(E_RoleStatus.None);
            transform.SetParent(PanelCellRole_.RootPortrait, false);
            RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
            RootExpeditionRole = null;
        }        
        else
        {
            if (Hot.NowRootExpeditionRole != null)
            {
                if (Hot.NowRootExpeditionRole.transform.childCount != 0)
                {
                    Hot.ReplaceRolePortrait = Hot.NowRootExpeditionRole.GetComponentInChildren<PanelCellRolePortraitCanDrag>().gameObject;

                    if (RootExpeditionRole != null)
                    {
                        Hot.ReplaceRolePortrait.transform.SetParent(RootExpeditionRole);
                        Hot.ReplaceRolePortrait.transform.localPosition = Vector3.zero;
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().PanelCellRole_.Index].IndexExpedition =
                            int.Parse((RootExpeditionRole.name.Replace("RootExpeditionRole", "")));

                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().RootExpeditionRole = RootExpeditionRole;
                    }
                    else
                    {
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().PanelCellRole_.Index].
                            e_RoleStatus = E_RoleStatus.None;
                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().PanelCellRole_.
                            ChangeRoleStatus(E_RoleStatus.None);
                        Hot.DataNowCellGameArchive.ListCellRole
                            [Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().PanelCellRole_.Index].
                            IndexExpedition = -1;
                        Hot.ReplaceRolePortrait.GetComponentInChildren<PanelCellRolePortraitCanDrag>().RootExpeditionRole = null;

                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_RoleStatus =
                            E_RoleStatus.Expedition;
                        PanelCellRole_.ChangeRoleStatus(E_RoleStatus.Expedition);
                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition = 
                            int.Parse(Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", ""));

                        Hot.ReplaceRolePortrait.transform.
                            SetParent(Hot.ReplaceRolePortrait.GetComponent<PanelCellRolePortraitCanDrag>().PanelCellRole_.RootPortrait, false);                        
                        Hot.ReplaceRolePortrait.GetComponent<PanelCellRolePortraitCanDrag>().RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                        Hot.ReplaceRolePortrait.transform.localPosition = Vector3.zero;                        
                    }

                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);                                      
                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));                                  
                }
                else
                {                    
                    if (RootExpeditionRole == null)
                    {
                        Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].e_RoleStatus = 
                            E_RoleStatus.Expedition;
                        PanelCellRole_.ChangeRoleStatus(E_RoleStatus.Expedition);
                        RectRolePortraitCanDrag.sizeDelta = new Vector2(100, 100);
                    }
                    Hot.DataNowCellGameArchive.ListCellRole[PanelCellRole_.Index].IndexExpedition =
                        int.Parse((Hot.NowRootExpeditionRole.name.Replace("RootExpeditionRole", "")));                    
                    transform.SetParent(Hot.NowRootExpeditionRole.transform, false);                    
                }

                RootExpeditionRole = Hot.NowRootExpeditionRole.transform;
            }
            else
            {
                if (RootExpeditionRole == null)
                {
                    transform.SetParent(PanelCellRole_.RootPortrait, false);
                    RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                }
                else
                {
                    transform.SetParent(RootExpeditionRole, false);                    
                }
            }
        }

        transform.localPosition = Vector3.zero;

        Hot.DragingRolePortrait = null;
        Hot.ReplaceRolePortrait = null;
        Hot.NowRootExpeditionRole = null;                
        
        Hot.Data_.Save();
    }

    #endregion

    public void Init()
    {
        transform.FindSonSonSon("ImgRolePortraitCanDrag").GetComponent<Image>().sprite = PanelCellRole_.ImgRolePortrait.sprite;
    }
}