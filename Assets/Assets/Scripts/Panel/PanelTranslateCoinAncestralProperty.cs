using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PanelTranslateCoinAncestralProperty : PanelBase
{
    private List<E_SpriteNameCoin> ListBtnCoinStatus = new List<E_SpriteNameCoin>()
    { 
        E_SpriteNameCoin.Copper,
        E_SpriteNameCoin.Silver,
        E_SpriteNameCoin.Gold        
    };

    private List<E_AncestralProperty> ListBtnAncestralPropertyStatus = new List<E_AncestralProperty>()
    {
        E_AncestralProperty.Statue,
        E_AncestralProperty.Deed,
        E_AncestralProperty.Picture,
        E_AncestralProperty.Badge,
        E_AncestralProperty.Crystal
    };

    private int NowIndexCoin = 0;
    private int NowIndexAncestralProperty = 0;    

    private Image ImgAncestralProperty;
    private Image ImgCoin;

    protected override void Awake()
    {
        base.Awake();

        ImgAncestralProperty = transform.FindSonSonSon("ImgAncestralProperty").GetComponent<Image>();
        ImgCoin = transform.FindSonSonSon("ImgCoin").GetComponent<Image>();

        ImgAncestralProperty.alphaHitTestMinimumThreshold = 0.2f;
        ImgCoin.alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgArrowCoinUp").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgArrowCoinDown").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgArrowAncestralPropertyUp").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
        transform.FindSonSonSon("ImgArrowAncestralPropertyDown").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;

        UpdateImg();
    }

    protected override void Button_OnClick(string controlname)
    {
        base.Button_OnClick(controlname);

        switch (controlname)
        {
            case "BtnCoin":
                Translate(E_ArrowDirection.Left);
                break;
            case "BtnAncestralProperty":
                Translate(E_ArrowDirection.Right);
                break;
            case "BtnArrowCoinUp":
                UpdateBtnCoinStatus(E_ArrowDirection.Up);
                break;
            case "BtnArrowCoinDown":
                UpdateBtnCoinStatus(E_ArrowDirection.Down);
                break;
            case "BtnArrowAncestralPropertyUp":
                UpdateBtnAncestralPropertyStatus(E_ArrowDirection.Up);
                break;
            case "BtnArrowAncestralPropertyDown":
                UpdateBtnAncestralPropertyStatus(E_ArrowDirection.Down);
                break;                
        }
    }

    private void Translate(E_ArrowDirection e_ArrowDirection)
    {
        switch (ListBtnCoinStatus[NowIndexCoin])
        {
            case E_SpriteNameCoin.Copper:
                switch (ListBtnAncestralPropertyStatus[NowIndexAncestralProperty])
                {
                    case E_AncestralProperty.Statue:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowStatue >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateStatueToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateStatueToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateStatueToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Deed:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowPicture >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowBadge >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Crystal:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper += Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowCopper >= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowCopper -= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                }
                break;
            case E_SpriteNameCoin.Silver:
                switch (ListBtnAncestralPropertyStatus[NowIndexAncestralProperty])
                {
                    case E_AncestralProperty.Statue:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowStatue >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Deed:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowPicture >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowBadge >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Crystal:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver += Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowSilver >= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowSilver -= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                }
                break;
            case E_SpriteNameCoin.Gold:
                switch (ListBtnAncestralPropertyStatus[NowIndexAncestralProperty])
                {
                    case E_AncestralProperty.Statue:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowStatue >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowStatue += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateStatueToSilver * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Deed:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowDeed >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowDeed += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateDeedToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Picture:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowPicture >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowPicture += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RatePictureToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Badge:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowBadge >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowBadge += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateBadgeToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                    case E_AncestralProperty.Crystal:
                        switch (e_ArrowDirection)
                        {
                            case E_ArrowDirection.Left:
                                if (Hot.DataPanelResTable.NowCrystal >= Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal -= Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold += Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                            case E_ArrowDirection.Right:
                                if (Hot.DataPanelResTable.NowGold >= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate)
                                {
                                    Hot.DataPanelResTable.NowCrystal += Hot.NowTranslateRate;
                                    Hot.DataPanelResTable.NowGold -= Hot.DataPanelResTable.RateCrystalToCopper * Hot.NowTranslateRate;
                                }
                                break;
                        }
                        break;
                }
                break;
        }

        Hot.PanelOtherResTable_.UpdateInfo();        
    }

    private void UpdateBtnCoinStatus(E_ArrowDirection e_ArrowDirection )
    {
        switch (e_ArrowDirection)
        {
            case E_ArrowDirection.Up:                
                if (--NowIndexCoin < 0)
                    NowIndexCoin = ListBtnCoinStatus.Count - 1;
                break;
            case E_ArrowDirection.Down:                
                if (++NowIndexCoin > ListBtnCoinStatus.Count - 1)
                    NowIndexCoin = 0;
                break;            
        }

        UpdateImg();
    }

    private void UpdateBtnAncestralPropertyStatus(E_ArrowDirection e_ArrowDirection)
    {
        switch (e_ArrowDirection)
        {
            case E_ArrowDirection.Up:                
                if (--NowIndexAncestralProperty < 0)
                    NowIndexAncestralProperty = ListBtnAncestralPropertyStatus.Count - 1;
                break;
            case E_ArrowDirection.Down:                
                if (++NowIndexAncestralProperty > ListBtnAncestralPropertyStatus.Count - 1)
                    NowIndexAncestralProperty = 0;
                break;            
        }

        UpdateImg();
    }

    private void UpdateImg()
    {
        ImgCoin.sprite = Hot.MgrRes_.Load<Sprite>("Art/ResCoin" + ListBtnCoinStatus[NowIndexCoin].ToString());
        ImgAncestralProperty.sprite = 
            Hot.MgrRes_.Load<Sprite>("Art/ResAncestralProperty" + ListBtnAncestralPropertyStatus[NowIndexAncestralProperty].ToString());
    }
}