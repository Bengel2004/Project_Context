using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OutLineManager))]
public class Managers : MonoBehaviour
{
    public static Managers Inst = null;

    public static OutLineManager Out = null;

    private void Awake()
    {
        if (Inst != null)
            Destroy(Inst);
        Inst = this;

        Out = GetComponent<OutLineManager>();

    }
}
