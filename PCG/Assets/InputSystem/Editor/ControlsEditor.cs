using System;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(KeyData))]
public class ControlsEditor : Editor
{
    KeyData keyData;
    string KeyName;
    string keyCode;

    Vector2 position;
    bool displayData;

    public void OnEnable()
    {
       keyData = (KeyData)target;
    }

    public override void OnInspectorGUI()
    {
       

        EditorGUILayout.LabelField("Key Name");
        KeyName = GUILayout.TextField(KeyName);

        EditorGUILayout.LabelField("Key Code");
        keyCode = GUILayout.TextField(keyCode);

        base.OnInspectorGUI();


        if (keyData.buttonKeys.Count == 0)
        {    
            EditorGUILayout.HelpBox("No Control Data Set", MessageType.Info);

            if (GUILayout.Button("Create Key Data List", EditorStyles.miniButton))
            {
                KeyCode tmp;
                try
                {
                    tmp = (KeyCode)Enum.Parse(typeof(KeyCode), keyCode);
                    keyData.SetKeys(KeyName, tmp);

                    EditorGUILayout.HelpBox("Key Data Added", MessageType.Error);
                }
                catch(ArgumentException)
                {
                    EditorGUILayout.HelpBox("Key Code Entered is not a valid key", MessageType.Error);
                }
             
            }
        }
        else
        {
            displayData = EditorGUILayout.Foldout(displayData, "Key Binding Data");
           

            if (GUILayout.Button("Add Entry", EditorStyles.miniButton))
            {
                KeyCode tmp;
                try
                {
                    tmp = (KeyCode)Enum.Parse(typeof(KeyCode), keyCode);
                    keyData.SetKeys(KeyName, tmp);
                }
                catch (ArgumentException)
                {
                    EditorGUILayout.HelpBox("Key Code Entered is not a valid key", MessageType.Error);
                }
            }


            if (displayData)
            {
                position = EditorGUILayout.BeginScrollView(position);

                for (int i = 0; i < keyData.buttonKeys.Count; i++)
                {
                    GUILayout.BeginHorizontal("box");

                    EditorGUILayout.LabelField(keyData.buttonKeys[i].Name);

                    EditorGUILayout.LabelField(keyData.buttonKeys[i].Code.ToString());


                    GUILayout.EndHorizontal();
                }

                EditorGUILayout.EndScrollView();
  
            }
        }

    }
}