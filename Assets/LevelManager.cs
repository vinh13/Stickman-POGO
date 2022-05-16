using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LEVEL
{
    public string Name;
    public int Price;
}

public class LevelManager : MonoBehaviour
{
    public string Current_NameMode = "";
    public int numberLevel = 12;
    [Header("MAX LEVEL 12")]
    public List<LEVEL> listLevel = new List<LEVEL>();
    public RectTransform rectGridLevel;
    ButtonSelectLevel[] btnLevels;

    void Awake()
    {
        btnLevels = rectGridLevel.GetComponentsInChildren<ButtonSelectLevel>();
    }


    public void ShowLevel(string nameMode, int _numberLevel)
    {
        Current_NameMode = nameMode;
        numberLevel = _numberLevel;



        for (int i = 0; i < listLevel.Count; i++)
        {
            listLevel[i].Name = Current_NameMode;

            bool actived = i < numberLevel ? true : false;
            btnLevels[i].Setup(listLevel[i], i, actived);
        }
    }
}
