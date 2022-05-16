using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MODE
{
    public string Name;
    public int NumberLevel;
    public Sprite sprPreview;
    public int PriceUnlock;
    public bool disable;
}

public class ModeManager : MonoBehaviour
{


    public static ModeManager Instance;

    public RectTransform rectContent;
    public List<MODE> listMode = new List<MODE>();
    public GameObject btnModePref;
    [SerializeField] LevelManager levelManager;
    [SerializeField] AnimatorPopUpScript UIMode, UILevel;
    List<ButtonSelectMode> listBtnSelectMode = new List<ButtonSelectMode>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        for (int i = 0; i < listMode.Count; i++)
        {
            GameObject temp = Instantiate(btnModePref) as GameObject;
            temp.transform.SetParent(rectContent);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.GetComponent<ButtonSelectMode>().Setup(listMode[i], i);
            listBtnSelectMode.Add(temp.GetComponent<ButtonSelectMode>());
        }
    }

    void Start()
    {

        int highScore = 0;
        for (int i = 0; i < listMode.Count; i++)
        {
            highScore += listBtnSelectMode[i].GetTotalScore();
        }
        PlayerPrefs.SetInt("SINGLE_SCORE", highScore);
        PlayerPrefs.Save();
    }

    #region On Select Mode

    public void OnSlectMode(int idMode)
    {

        Logic.NameMode = listMode[idMode].Name;
        Logic.NumberLevel = listMode[idMode].NumberLevel;


        levelManager.ShowLevel(listMode[idMode].Name, listMode[idMode].NumberLevel);
        UILevel.gameObject.SetActive(true);
        UILevel.show();
    }

    #endregion

    public void HideLevel()
    {
        UILevel.hide();
    }

    public void ShowUIMode()
    {
        UIMode.gameObject.SetActive(true);
        UIMode.show();
    }

    public void HideUIMode()
    {
        UIMode.hide();

        Logic.UNPAUSE();
    }



    #region OnSelect LEVEL

    public void OnSlectLevel()
    {
        Manager.Instance.LoadSceneActivate(1);
        StartCoroutine(delayOnSlectLevel());
    }

    IEnumerator delayOnSlectLevel()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Manager.Instance.loadSceneNow = true;
    }

    #endregion
}
