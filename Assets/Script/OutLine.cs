using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{
    SpriteRenderer srenderer;
    MaterialPropertyBlock mtProperty;

    private void Awake()
    {
        srenderer = GetComponent<SpriteRenderer>();
        mtProperty = new MaterialPropertyBlock();
    }

    private void Update()
    {
        if (OutLineCtrl.Inst.CompareHitObject(this.gameObject))
        {
            StartCoroutine(ISetOutLineMaterial(true));
        }
        else
            StartCoroutine(ISetOutLineMaterial(false));
    }

    private IEnumerator ISetOutLineMaterial(bool enable)
    {
        srenderer.GetPropertyBlock(mtProperty);
        mtProperty.SetFloat("_OutlineEnabled", System.Convert.ToInt32(enable));
        srenderer.SetPropertyBlock(mtProperty);
        yield break;
    }

}
