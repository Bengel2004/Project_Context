using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineManager : MonoBehaviour
{
    private OutLine presentForcusObject = null;
    private SelectBase optionBox = null;

    public OutLine PresentForcusObject { get => presentForcusObject; set => presentForcusObject = value; }
    public SelectBase OptionBox { get => optionBox; set => optionBox = value; }
}
