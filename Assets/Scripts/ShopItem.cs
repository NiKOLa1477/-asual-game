using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    private void Start()
    {
        StreamReader starsdata = new StreamReader(Application.persistentDataPath + "/stars.gd");
        stars = int.Parse(starsdata.ReadLine());
        starsdata.Close();
        sm.CheckItemButtons();
    }

    public enum ItemType
    {
        First_skin,
        Second_skin,
        Third_skin,
    }

    public ItemType type;
    public Button BuyBtn, ActivateBtn;
    public bool IsBought;
    public int Cost;
    int stars;

    bool isActive
    {
        get
        {
            return type == sm.ActiveSkin;
        }
    }

    GM ms;
    public ShopManager sm;

    public void Init()
    {
        ms = FindObjectOfType<GM>();
    }

    public void CheckButtons()
    {
        BuyBtn.gameObject.SetActive(!IsBought);
        BuyBtn.interactable = CanBuy();

        ActivateBtn.gameObject.SetActive(IsBought);
        ActivateBtn.interactable = !isActive;
    }

    bool CanBuy()
    {
        return stars >= Cost;
    }

    public void BuyItem()
    {
        if (!CanBuy())
            return;

        IsBought = true;
        stars -= Cost;
        StreamWriter starsdata = new StreamWriter(Application.persistentDataPath + "/stars.gd");
        starsdata.WriteLine(stars);
        starsdata.Close();

        CheckButtons();
        SaveS.Instance.SaveGame();
    }

    public void ActivateItem()
    {
        sm.ActiveSkin = type;
        sm.CheckItemButtons();

        switch(type)
        {
            case ItemType.First_skin:
                ms.ActivateSkin(0);
                break;
            case ItemType.Second_skin:
                ms.ActivateSkin(1);
                break;
            case ItemType.Third_skin:
                ms.ActivateSkin(2);
                break;
        }

        SaveS.Instance.SaveGame();
    }

}
