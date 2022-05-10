using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CollisionBasedTrigger : MonoBehaviour
{
    [SerializeField] protected Color triggerBoxColor = new Color(1,0,0,.5f);
    [FoldoutGroup("enter events")] [SerializeField] protected UnityEvent enterEvents = new UnityEvent();
    [FoldoutGroup("exit events")] [SerializeField] protected UnityEvent exitEvents = new UnityEvent();
    [SerializeField] protected bool supportMultiTag;

    #region SingleTag

    [HideIf("supportMultiTag")]
    [ValueDropdown("Tags")] public string otherTag;
#if UNITY_EDITOR
    string[] Tags { get{ return UnityEditorInternal.InternalEditorUtility.tags;} }
#endif

    #endregion

    #region MultiTag
    
    [HideInInspector] [SerializeField] int tagValue = 0; // should be serialized otherwise unity will assign default value when enter play mode which is zero 
    string[] options;
    [HideInInspector] [SerializeField] protected List<string> tags = new List<string>(); // should be serialized otherwise unity will assign default value which is null

#if UNITY_EDITOR
    [OnInspectorGUI]
    [ShowIf("supportMultiTag")]
    void ShowTagInspector()
    {
        options = UnityEditorInternal.InternalEditorUtility.tags;
        tagValue = EditorGUILayout.MaskField("Tags", tagValue, options);
        if (tagValue == 0) // nothing selected
        {
            if (tags != null)
            {
                tags.Clear();
            }
        }
        else if (tagValue == -1) // everything everything selected
        {
            tags.Clear();
            foreach (var option in options)
            {
                tags.Add(option);
            }
        }
        else // one or more tag selected
        {
            string binaryRepresentation = Convert.ToString(tagValue, 2).PadLeft(32, '0'); // binary representation of layerMask
            
            // loop on last binary representation string
            for (int i = 0; i < options.Length; i++)
            {
                char currentBitMaskValue = binaryRepresentation[binaryRepresentation.Length - 1 - i]; // getting value from end of the string
                
                if (currentBitMaskValue == '1')
                {
                    if (!tags.Contains(options[i]))
                    {
                        tags.Add(options[i]);
                    }
                }
                else
                {
                    if (tags.Contains(options[i]))
                    {
                        tags.Remove(options[i]);
                    }
                }
            }
        }
    }
#endif

    #endregion
    
    
    void Reset()
    {
        // specific to single tag support
        otherTag = "Untagged";
        
        // specific to multi tag support
        tagValue = 0; // set default dropdown value to Nothing it means object is not have any tags
        
        // general
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().isTrigger = true;
    } 
}