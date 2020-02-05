using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{
    private SpriteRenderer srenderer;
    private MaterialPropertyBlock mtProperty;

    private Camera cam;

    private const float h = 2.5f;
    private const float v = 3f;

    private int horizontal;
    private int vertical;

    private void Awake()
    {
        srenderer = GetComponent<SpriteRenderer>();
        mtProperty = new MaterialPropertyBlock();

        cam = Camera.main;
    }

    private void OnMouseEnter()
    {
        SetOutLineMaterial(true);
        horizontal = GetAwayFromCenterHorizontal(gameObject);
        vertical = GetAwayFromCenterVertical(gameObject);
    }

    private void OnMouseExit()
    {
        if (Managers.Out.PresentForcusObject != null)
        {
            if (!Managers.Out.PresentForcusObject.Equals(this))
                SetOutLineMaterial(false);
        }
        else
            SetOutLineMaterial(false);
    }

    private void OnMouseDown()
    {
        Destroy(GameObject.Find("[SelectBoxBack](Clone)"));

        if (Managers.Out.PresentForcusObject != null)
        {
            //delete option box (none anim)
            Managers.Out.PresentForcusObject.SetOutLineMaterial(false);
            if (Managers.Out.PresentForcusObject.Equals(this))
                Managers.Out.PresentForcusObject = null;
            else
            {
                //make option box
                StartCoroutine(CreateBox().ICreate(gameObject.transform.position + new Vector3(h * horizontal, v * vertical)));
                Managers.Out.PresentForcusObject = this;
            }
        }
        else
        {
            //make option box
            StartCoroutine(CreateBox().ICreate(gameObject.transform.position + new Vector3(h * horizontal, v * vertical)));
            Managers.Out.PresentForcusObject = this;
        }
    }

    private SelectBase CreateBox()
    {
        return Instantiate(Resources.Load<GameObject>("Prefabs/[SelectBoxBack]"),
                    gameObject.transform.position, Quaternion.identity, GameObject.Find("[UI]").transform).GetComponent<SelectBase>();
    }

    public void SetOutLineMaterial(bool enable)
    {
        srenderer.GetPropertyBlock(mtProperty);
        mtProperty.SetFloat("_OutlineEnabled", System.Convert.ToInt32(enable));
        srenderer.SetPropertyBlock(mtProperty);
    }

    private int GetAwayFromCenterHorizontal(GameObject obj)
    {
        if (obj.transform.position.x > cam.transform.position.x)
            return -1;
        else if (obj.transform.position.x < cam.transform.position.x)
            return 1;
        else
            return 0;
    }

    private int GetAwayFromCenterVertical(GameObject obj)
    {
        if (obj.transform.position.y > cam.transform.position.y)
            return -1;
        else if (obj.transform.position.y < cam.transform.position.y)
            return 1;
        else
            return 0;
    }

}
