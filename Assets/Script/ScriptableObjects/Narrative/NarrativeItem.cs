using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Narrative Item", menuName = "ScriptableObjects/Narrative Item", order = 1)]
public class NarrativeItem : ScriptableObject
{
    public List<NarrativeObj> narrativeObj;
}

[System.Serializable]
public class NarrativeObj
{
    public Sprite narrativePerson;
    public string narrativeText;
}