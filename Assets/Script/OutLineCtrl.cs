using System.Collections;
using UnityEngine;

public class OutLineCtrl : MonoBehaviour
{
    public static OutLineCtrl Inst = null;

    private Camera cam;
    private GameObject hitObject = null;

    private void Awake()
    {
        if (Inst != null)
            Destroy(Inst);

        Inst = this;

        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D raycast = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        if (raycast.collider != null)
            hitObject = raycast.collider.gameObject;
        else
            hitObject = null;
    }

    public bool CompareHitObject(GameObject obj)
    {
        if(hitObject != null)
            return hitObject.Equals(obj);
        return false;
    }

    public IEnumerator ICreateSelectBox(GameObject obj)
    {
        //Instantiate(Resources.Load<"">)
        yield break;
    }

}
