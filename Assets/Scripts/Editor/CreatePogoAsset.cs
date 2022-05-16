using UnityEditor;
using UnityEngine;

public class CreatePogoAsset
{
	[MenuItem ("PogoAsset/HandWeaponConfig")]
	public static void CreateAssetHandWeaponConfig ()
	{
		ScriptableObjectUtility.CreateAsset<HandWeaponConfig> ();
	}
}
