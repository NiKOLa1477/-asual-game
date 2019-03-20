using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveS : MonoBehaviour
{
    public ShopManager sm;
    public GM gm;
    string filePath;

    public static SaveS Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        gm = FindObjectOfType<GM>();
        filePath = Application.persistentDataPath + "data.gamesave";

        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.ActiveSkinIndex = (int)sm.ActiveSkin;
        save.SaveBoughtItems(sm.Items);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        sm.ActiveSkin = (ShopItem.ItemType)save.ActiveSkinIndex;

        for (int i = 0; i < save.BoughtItems.Count; i++)
            sm.Items[i].IsBought = save.BoughtItems[i];

        fs.Close();
    }
}

[System.Serializable]
public class Save
{
    public int ActiveSkinIndex;
    public List<bool> BoughtItems = new List<bool>();

    public void SaveBoughtItems(List<ShopItem> items)
    {
        foreach (var item in items)
            BoughtItems.Add(item.IsBought);
    }
}
