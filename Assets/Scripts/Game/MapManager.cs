using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField]Text TextLevel;
	[Header("MODE TEST")]
	public bool TEST = false;
    public GameObject[] mapResources;

    public int idCurrentLevel = 0;


    void  Awake()
    {
        idCurrentLevel = Logic.IdLevel;
        TextLevel.text = "LEVEL: " + (idCurrentLevel);

        idCurrentLevel -= 1;

		if (!TEST) {
			GameObject mapCurrent = HierarchicalPrefabUtility.Instantiate (mapResources [idCurrentLevel], Vector3.zero, Quaternion.identity);
		}
    }

    void Start()
    {


    }
	public void ChangeSKin(int id){
		
	}
}
