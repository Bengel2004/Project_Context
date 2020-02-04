using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLine : MonoBehaviour
{
    private SpriteRenderer srenderer;
    private MaterialPropertyBlock mtProperty;

    private Camera cam;

    private bool isEnter = false;
    private bool isStay = false;

    private static GameObject selectBox = null;

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

    private void FixedUpdate()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycast = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        if (raycast.collider != null)
        {
            if (raycast.collider.gameObject.Equals(gameObject))
            {
                if (!isEnter)
                {
                    isEnter = true;
                    isStay = true;
                    StartCoroutine(IEnter());
                }
                else if (isEnter && isStay)
                    StartCoroutine(IStay());
            }
        }
        else if (isEnter && isStay)
        {
            isEnter = false;
            isStay = false;
            StartCoroutine(IExit());
        }
    }

    private IEnumerator IEnter()
    {
        SetOutLineMaterial(true);

        horizontal = GetAwayFromCenterHorizontal(gameObject);
        vertical = GetAwayFromCenterVertical(gameObject);
        yield break;
    }

    private IEnumerator IStay()
    {
        print(gameObject.name + "Stay");
        if (Input.GetMouseButtonDown(0))
        {
            print(gameObject.name + ":Click");
            if (selectBox == null)
            {
                selectBox = Instantiate(Resources.Load<GameObject>("Prefabs/[SelectBoxBack]"),
                      gameObject.transform.position, Quaternion.identity, GameObject.Find("[UI]").transform);
                StartCoroutine(selectBox.GetComponent<SelectBase>().ICreate(gameObject.transform.position + new Vector3(horizontal * h, vertical * v)));
            }
            //else
            //{
            //    Destroy(selectBox);
            //    selectBox = Instantiate(Resources.Load<GameObject>("Prefabs/[SelectBoxBack]"),
            //          gameObject.transform.position, Quaternion.identity, GameObject.Find("[UI]").transform);
            //    StartCoroutine(selectBox.GetComponent<SelectBase>().ICreate(gameObject.transform.position + new Vector3(horizontal * h, vertical * v)));
            //}
        }
        yield break;
    }

    private IEnumerator IExit()
    {
        SetOutLineMaterial(false);
        yield break;
    }

    private void SetOutLineMaterial(bool enable)
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
