#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor (typeof(MusicManager))]
public class MusicManagerInspector : Editor
{


	public override void OnInspectorGUI ()
	{
		MusicManager mManager = target as MusicManager;

		foreach (var scene in EditorBuildSettings.scenes) {
			string sceneName = Path.GetFileNameWithoutExtension (scene.path);
			if (!mManager.backgroundMusics.ContainsKey (sceneName)) {
				mManager.backgroundMusics.Add (sceneName, null);
			}

			if (mManager.backgroundMusics [sceneName] == null) {
				GUI.contentColor = Color.yellow;
			} else {
				GUI.contentColor = Color.green;
			}
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField (sceneName);
			mManager.backgroundMusics [sceneName] = EditorGUILayout.ObjectField (mManager.backgroundMusics [sceneName], typeof(AudioClip), true) as AudioClip;
			EditorGUILayout.EndHorizontal ();
		}
	}
}
#endif
