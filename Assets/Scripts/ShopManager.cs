using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<ShopItem> Items;
    public ShopItem.ItemType ActiveSkin;

    void Start()
    {
        CheckItemButtons();
        gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
    }

    public void CheckItemButtons()
    {
        foreach (ShopItem item in Items)
        {
            item.sm = this;
            item.Init();
            item.CheckButtons();
        }
    }
}
