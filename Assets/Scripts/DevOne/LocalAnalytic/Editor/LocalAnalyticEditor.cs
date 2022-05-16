using System.Collections;
using System.Collections.Generic;
using DevOne.Analytic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DevOne.Analytic
{
    [CustomEditor(typeof(LocalAnalytic))]
    public class LocalAnalyticEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            LocalAnalytic myTarget = (LocalAnalytic)target;
            GUI.color = Color.red;
            EditorGUILayout.LabelField("All Analytic local should implement at Start() function for correct", EditorStyles.boldLabel);
            GUI.color = Color.black;
            EditorGUILayout.LabelField("* Log App Number: " + myTarget.logAppNumber, EditorStyles.boldLabel);
            EditorGUILayout.LabelField("* Log Day Number: " + myTarget.logAppDay, EditorStyles.boldLabel);
            EditorGUILayout.LabelField("* Log App Number In Day: " + myTarget.logAppNumberInDay, EditorStyles.boldLabel);

            EditorGUILayout.LabelField("* Time In Game: " + myTarget.timeInGame, EditorStyles.boldLabel);
            EditorGUILayout.LabelField("* Time In Game In Day:  " + myTarget.timeInGameToDay, EditorStyles.boldLabel);
            EditorUtility.SetDirty(target);
        }
    }
}
#endif
