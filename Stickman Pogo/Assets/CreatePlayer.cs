using UnityEngine;
using System.Collections;

public class CreatePlayer : MonoBehaviour
{
    public GameObject playerPref;
    GameObject currentPlayer;

    void Awake()
    {
        _CreatePlayer(transform.position);
    }

    public void _CreatePlayer(Vector3 pos)
    {
        if (currentPlayer != null)
        {
            currentPlayer.GetComponent<StickmanConfig>().RemoveTarget();
            Destroy(currentPlayer);
        }
        GameObject temp = Instantiate(playerPref, pos, Quaternion.AngleAxis(0, Vector3.forward)) as GameObject;
        currentPlayer = temp;
    }
}
