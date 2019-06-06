using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GM : MonoBehaviour
{
    public List<Skin> skins;
    int s;

    private void Start()
    {
        StreamReader skinsdata = new StreamReader(Application.persistentDataPath + "/skins.gd");
        s = int.Parse(skinsdata.ReadLine());
        skinsdata.Close();
        ActivateSkin(s);
    }

    public void ActivateSkin(int skinIndex)
    {
        foreach (var skin in skins)
            skin.HideSkin();
        StreamWriter skinsdata = new StreamWriter(Application.persistentDataPath + "/skins.gd");
        skinsdata.WriteLine(skinIndex);
        skinsdata.Close();
        skins[skinIndex].ShowSkin();
    }
}
