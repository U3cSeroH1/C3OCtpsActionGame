using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CreateCharacter", order = 1)]

public class Character : ScriptableObject
{

    public float HP;
    public float ST;
    public float MP;




#if UNITY_EDITOR
    //-------------------------------------------------------------------------
    [UnityEditor.CustomEditor(typeof(Item))]
    public class UIElementEditor : UnityEditor.Editor
    {
        //-------------------------------------------------
        // Custom Inspector GUI allows us to click from within the UI
        //-------------------------------------------------
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Character character = (Character)target;


        }
    }
#endif

}