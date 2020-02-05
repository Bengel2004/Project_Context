using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Inst = null;

    private OutLine presentForcusObject = null;
    private GameObject uiCanvas = null;

    public OutLine PresentForcusObject { get => presentForcusObject; set => presentForcusObject = value; }
    public GameObject UiCanvas { get => uiCanvas; set => uiCanvas = value; }

    private void Awake()
    {
        if (Inst != null)
            Destroy(Inst);
        Inst = this;

        uiCanvas = GameObject.Find("[UI]");
    }

}
