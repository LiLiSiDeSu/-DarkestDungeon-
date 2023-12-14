using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTownItem : PanelBaseVector2Store,
             IPointerEnterHandler, IPointerExitHandler
{    
    public InputField IptName;        

    public PanelCellTownStore PanelCellTownStore_;

    protected override void Awake()
    {
        base.Awake();

        IptName = transform.FindSonSonSon("IptName").GetComponent<InputField>();

        Hot.MgrUI_.AddCustomEventListener(IptName.gameObject, EventTriggerType.PointerEnter,
        (param) =>
        {
            Hot.MgrInput_.OpenOrCloseCheck(false);
        });
        Hot.MgrUI_.AddCustomEventListener(IptName.gameObject, EventTriggerType.PointerExit,
        (param) =>
        {
            Hot.MgrInput_.OpenOrCloseCheck(true);
        });
    }

    #region EventSystem

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hot.NowPanelCanStoreItem = this;
        Hot.e_NowPointerLocation = E_NowPointerLocation.PanelTownItem;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hot.NowPanelCanStoreItem = null;
        Hot.e_NowPointerLocation = E_NowPointerLocation.None;
    }

    #endregion

    protected override void InputField_OnEndEdit(string controlname, string EventParam)
    {
        base.InputField_OnEndEdit(controlname, EventParam);

        switch (controlname)
        {
            case "IptName":
                PanelCellTownStore_.Rename(EventParam);
                break;
        }
    }

    public void Hide()
    {
        Hot.MgrUI_.HidePanel(false, gameObject, gameObject.name);
    }

    public void Show()
    {
        Hot.MgrUI_.ShowPanel<PanelTownItem>(true, gameObject.name,
        (panel) =>
        {
            panel.transform.SetParent(Hot.PanelBarTownStore_.RootPanelTownItem, false);
        });
    }

    public void ShowForBtn()
    {
        if (PoolNowPanel.GetInstance().ListNowPanel.Contains(gameObject.name))
            Hide();
        else
            Show();
    }

    public override void UpdateInfoByAdd(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByAdd(p_e_Item);

        PanelCellTownStore_.TxtCapacity.text =
            NowCapacity + " / " + Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X * Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y;
    }

    public override void UpdateInfoByReduce(E_SpriteNamePanelCellItem p_e_Item)
    {
        base.UpdateInfoByReduce(p_e_Item);

        PanelCellTownStore_.TxtCapacity.text =
            NowCapacity + " / " + Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X * Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y;
    }

    public void InitTxtCapacity()
    {
        foreach (List<DataContainer_CellItem> listItem in Hot.DataNowCellGameArchive.StoreList[PanelCellTownStore_.Index].ListItem)
        {
            foreach (DataContainer_CellItem item in listItem)
            {
                if (item.e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    NowCapacity += Hot.BodyDicItem[item.e_SpriteNamePanelCellItem].X * Hot.BodyDicItem[item.e_SpriteNamePanelCellItem].Y;
                }
            }
        }

        PanelCellTownStore_.TxtCapacity.text = 
           PanelCellTownStore_.PanelCellItem_.NowCapacity + " / " + 
           Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X * 
           Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y;
    }

    public void InitContent()
    {
        IptName.text = Hot.DataNowCellGameArchive.StoreList[PanelCellTownStore_.Index].Name;

        InitGrids(Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y, Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X);

        LoadData();
    }    

    public void LoadData()
    {        
        for (int i1 = 0; i1 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].Y; i1++)
        {
            int tempi1 = i1;

            for (int i2 = 0; i2 < Hot.BodyDicStore[PanelCellTownStore_.e_PanelCellTownStore].X; i2++)
            {
                int tempi2 = i2;

                if (Hot.DataNowCellGameArchive.StoreList[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem != E_SpriteNamePanelCellItem.None)
                {
                    Hot.MgrUI_.CreatePanel<PanelCellItem>(false, "/PanelCellItem",
                    (PanelCellItem_) =>
                    {
                        PanelCellItem_.transform.SetParent(ItemRoot[tempi1][tempi2], false);
                        PanelCellItem_.transform.localPosition = Vector3.zero;

                        PanelCellItem_.RootGrid = Grids[tempi1][tempi2];
                        PanelCellItem_.MemberOf = this;
                        PanelCellItem_.e_Location = E_ItemLocation.PanelTownItem;
                        PanelCellItem_.e_Item = Hot.DataNowCellGameArchive.StoreList[PanelCellTownStore_.Index].ListItem[tempi1][tempi2].e_SpriteNamePanelCellItem;

                        PanelCellItem_.ImgItem.sprite = Hot.MgrRes_.Load<Sprite>("Art/" + PanelCellItem_.e_Item);

                        PanelCellItem_.ChangeCellSize();

                        for (int i1 = 0; i1 < Hot.BodyDicItem[PanelCellItem_.e_Item].Y; i1++)
                        {
                            for (int i2 = 0; i2 < Hot.BodyDicItem[PanelCellItem_.e_Item].X; i2++)
                            {
                                Grids[tempi1 + i1][tempi2 + i2].Item = PanelCellItem_;
                            }
                        }
                    });
                }
            }
        }        
    }        
}
