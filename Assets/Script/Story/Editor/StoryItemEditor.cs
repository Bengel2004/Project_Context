//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(StoryItem))]
//public class StoryItemEditor : Editor
//{
//    /*
//    public override void OnInspectorGUI()
//    {
//        var myScript = target as StoryItem;
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("item"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("task"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("isLastItem"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("skipDayItem"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("currentSunPos"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("DaySunPos"), true);
//        //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("sun"), true);
//        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("organism"), true);
//        //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("growButton"), true);
//        //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("taskItem"), true);

//        EditorGUILayout.Space(10);
//        EditorGUILayout.LabelField("Narrative", EditorStyles.boldLabel);

//        myScript.showText = GUILayout.Toggle(myScript.showText, "Enable Narrative");
//        if (myScript.showText)
//        {
//            this.serializedObject.Update();
//            //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("endOfDayText"), true); // ! DELETE DEZE LATER !
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("narItem"), true);
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("infoView"), true);
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("infoViewText"), true);
//            this.serializedObject.ApplyModifiedProperties();
//        }


//        EditorGUILayout.Space(10);
//        EditorGUILayout.LabelField("Events", EditorStyles.boldLabel);
//        myScript.startEventBool = GUILayout.Toggle(myScript.startEventBool, "Start Event");
//        if (myScript.startEventBool)
//        {
//            this.serializedObject.Update();
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("startEvent"), true);
//            this.serializedObject.ApplyModifiedProperties();
//        }

//        myScript.endEventBool = GUILayout.Toggle(myScript.endEventBool, "End Event");
//        if (myScript.endEventBool)
//        {
//            this.serializedObject.Update();
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("endEvent"), true);
//            this.serializedObject.ApplyModifiedProperties();
//        }

//        myScript.altBehaviour = GUILayout.Toggle(myScript.altBehaviour, "Alternative Behaviour");
//        if (myScript.altBehaviour)
//        {
//            this.serializedObject.Update();
//            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("eventType"), true);
//            this.serializedObject.ApplyModifiedProperties();
//        }
//    }
//    */
//}
