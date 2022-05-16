using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkinManager : MonoBehaviour {
	public GameObject[] listPlayer;
	public int idSkin = 0;
	void Awake(){
		for(int i =0 ; i < 2;i++){
			listPlayer [i].SetActive (false);
		}
		listPlayer [idSkin].SetActive (true);
	}
	public void ChangeSKin(int id){
		for(int i =0 ; i < 2;i++){
			listPlayer [i].SetActive (false);
		}
		listPlayer [id
		].SetActive (true);
	}
}
