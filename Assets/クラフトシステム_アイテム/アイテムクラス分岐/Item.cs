using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/CreateItem", order = 1)]

public class Item : ScriptableObject
{


    public enum ItemType
    {
        ToolItem,
        EffectItem,
    }

    public ItemType itemtype;

    //　アイテムのアイコン(ゲームオブジェクトのプレビューそんままつかうかんじ)
    [SerializeField]
    public GameObject DispgameObject;
    //　アイテムの名前
    [SerializeField]
    public string itemName;
    //　アイテムの情報
    [SerializeField]
    public string information;


    public int ItemSize;

    public float ItemWeight;

    //アイテムのレシピ
    //[HideInInspector]
    public List<Item> Recipe = new List<Item>();

    //子クラス用
    //[HideInInspector]
    public float attack;

    //[HideInInspector]
    public float block;

    //[HideInInspector]
    public float HP_effect;


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

            Item item = (Item)target;


        }
    }
#endif

}