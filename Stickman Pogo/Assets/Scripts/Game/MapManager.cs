using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField]Text TextLevel;

    public GameObject[] mapResources;

    public int idCurrentLevel = 0;

    void  Awake()
    {
        idCurrentLevel = Logic.IdLevel;
        TextLevel.text = "LEVEL: " + (idCurrentLevel);

        idCurrentLevel -= 1;

        GameObject mapCurrent = HierarchicalPrefabUtility.Instantiate(mapResources[idCurrentLevel], Vector3.zero, Quaternion.identity);
    }

    void Start()
    {


    }
}
