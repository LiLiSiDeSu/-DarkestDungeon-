using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCellRole : PanelBaseCellDynamicScrollView,
             IPointerEnterHandler, IPointerExitHandler
{
    public Image ImgRolePortrait;
    public Image ImgProgress;
    public Image ImgRoleLevelBk;
    public Image ImgRoleStatus;
    public Image ImgPanelBk;
    public Text TxtRoleName;
    public Text TxtRoleLevel;

    public Transform Root;
    public Transform RootPortrait;
    public Transform RootSanityValueBar;        

    public PanelCellRolePortraitCanDrag PanelCellRoleCanDrag_;

    public List<GameObject> ListImgCellSanity = new();   

    protected override void Awake()
    {
        base.Awake();

        PrefabsDynamicContentStepSuffix = "PanelCellRole";

        ImgRolePortrait = transform.FindSonSonSon("ImgRolePortrait").GetComponent<Image>();
        ImgProgress = transform.FindSonSonSon("ImgProgress").GetComponent<Image>();
        ImgRoleLevelBk = transform.FindSonSonSon("ImgRoleLevelBk").GetComponent<Image>();
        ImgRoleStatus = transform.FindSonSonSon("ImgRoleStatus").GetComponent<Image>();
        ImgPanelBk = transform.FindSonSonSon("ImgPanelBk").GetComponent<Image>();

        TxtRoleName = transform.FindSonSonSon("TxtRoleName").GetComponent<Text>();
        TxtRoleLevel = transform.FindSonSonSon("TxtRoleLevel").GetComponent<Text>();

        Root = transform.FindSonSonSon("Root");
        RootPortrait = transform.FindSonSonSon("RootPortrait");
        RootSanityValueBar = transform.FindSonSonSon("RootSanityValueBar");

        ImgRolePortrait.alphaHitTestMinimumThreshold = 0.2f;
    }

    #region EventSystem�ӿ�ʵ��

    public void OnPointerEnter(PointerEventData eventData)
    {
        Root.localPosition = new Vector3(0, 0, 0);        
    }

    public void OnPointerExit(PointerEventData eventData)
    {    
        Root.localPosition = new Vector3(30, 0, 0);        
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        Root.localPosition = new Vector3(30, 0, 0);
        ImgPanelBk.raycastTarget = false;

        Hot.PaddingContentStep_.transform.SetParent(Hot.PanelRoleList_.Content, false);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ImgPanelBk.raycastTarget = true;        
    }

    public override void EndDrag()
    {
        transform.SetParent(Hot.PaddingContentStep_.DependentObjRoot, false);
        transform.localPosition = Vector3.zero;
        DestroyImmediate(Hot.PanelRoleList_.ListDynamicContentStep[Index].gameObject);
        Hot.PanelRoleList_.SortContent();
        Hot.PaddingContentStep_ = null;
    }

    #endregion

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnRolePortrait":                
                Hot.PanelRoleDetails_.UpdateInfo(Hot.DataNowCellGameArchive.ListCellRole[Index]);
                Hot.MgrUI_.ShowPanel<PanelRoleDetails>(true, "PanelRoleDetails",
                (panel) =>
                {
                    panel.NowRole = this;
                    panel.BtnDismiss.SetActive(true);
                });                
                break;
        }
    }

    public void CreatePanelCellRoleCanDrag()
    {
        if (Hot.DataNowCellGameArchive.ListCellRole[Index].e_RoleStatus == E_RoleStatus.None)
        {
            Hot.MgrUI_.CreatePanel<PanelCellRolePortraitCanDrag>(false, "/PanelCellRolePortraitCanDrag",
            (panel) =>
            {
                panel.transform.SetParent(RootPortrait, false);
                panel.RectRolePortraitCanDrag.sizeDelta = new Vector2(80, 80);
                panel.PanelCellRole_ = this;
                PanelCellRoleCanDrag_ = panel;
                panel.Init();
            });
        }
    }

    public void InitInfo(DataContainer_CellRole Role)
    {
        ImgRolePortrait.sprite =Hot.MgrRes_.Load<Sprite>("Art/Portrait" + Role.e_RoleName);        

        TxtRoleName.text = Role.Name;
        TxtRoleLevel.text = Role.NowLevel.ToString();

        TxtRoleName.text = Role.Name;        
        ChangeSanityExplosionLimit();
        UpdateLevelInfo();
        UpdateSanityInfo();
        UpdateExperience();
        ChangeRoleStatus(Role.e_RoleStatus);
    }

    /// <summary>
    /// �ı�RootSanityValueBar�µ�ImgCellSanity������
    /// ��סһ��Ҫ��UpdateSanityInfoǰ����
    /// </summary>
    public void ChangeSanityExplosionLimit()
    {
        if (ListImgCellSanity.Count < Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion)
        {
            int v1 = Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion - ListImgCellSanity.Count;

            for 
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.Add(Hot.MgrRes_.Load<GameObject>("Prefabs/" + "ImgCellSanity"));
                ListImgCellSanity[i].transform.SetParent(RootSanityValueBar, false);
                ListImgCellSanity[i].GetComponent<Image>().sprite = 
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
            }
        }

        if (ListImgCellSanity.Count > Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion)
        {
            int v1 = ListImgCellSanity.Count - Hot.DataNowCellGameArchive.ListCellRole[Index].LimitToSanityExplosion;

            for
            (int i = 0; i < v1; i++)
            {
                ListImgCellSanity.RemoveAt(ListImgCellSanity.Count - 1);
            }
        }
    }

    public void ChangeName(string NameToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].Name = NameToChange;
        
        TxtRoleName.text = NameToChange;
        Hot.Data_.Save();
    }

    public void ChangeSanity(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity += ValueToChange;

        UpdateSanityInfo();
        Hot.Data_.Save();
    }

    public void ChangeExperience()
    {
        Hot.Data_.Save();
    }

    public void ChangeLevel(int ValueToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel += ValueToChange;
        if
        (Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel > Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel)
         Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel = Hot.DataNowCellGameArchive.ListCellRole[Index].MaxLevel;

        UpdateLevelInfo();
        Hot.Data_.Save();
    }

    public void ChangeRoleStatus(E_RoleStatus ToChange)
    {
        Hot.DataNowCellGameArchive.ListCellRole[Index].e_RoleStatus = ToChange;
        ImgRoleStatus.sprite = Hot.MgrRes_.Load<Sprite>("Art/RoleStatus" + ToChange.ToString());
    }

    public void UpdateSanityInfo()
    {
        for (int i = 0; i < ListImgCellSanity.Count; i++)
        {
            if
            (i < Hot.DataNowCellGameArchive.ListCellRole[Index].NowSanity / Hot.StepSanity)
            {
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueHave");
            }
            else
                ListImgCellSanity[i].GetComponent<Image>().sprite =
                    Hot.MgrRes_.Load<Sprite>("Art/" + "DecorateCellSanityValueNone");
        }
    }    

    public void UpdateLevelInfo()
    {
        //�ȼ��ĵ�ͼ�ı��߼�

        TxtRoleLevel.text = Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel.ToString();
    }

    public void UpdateExperience()
    {
        ImgProgress.GetComponent<RectTransform>().sizeDelta = 
            new Vector2(ImgProgress.GetComponent<RectTransform>().sizeDelta.x, 
                        49.3f * ((float)Hot.DataNowCellGameArchive.ListCellRole[Index].NowExperience /
                        Hot.ListNeedExperienceToUpLevel[Hot.DataNowCellGameArchive.ListCellRole[Index].NowLevel])); 
    }    
}