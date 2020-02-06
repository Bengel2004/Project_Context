using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cameraFollow;
    public static bool enableFollow = true;

    // Update is called once per frame
    void Update()
    {
        if (enableFollow)
        {
            //if(GameManager.Instance.currentAnimal == thisOrganism)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 temp = new Vector3(ray.origin.x, ray.origin.y, 0f);
            cameraFollow.transform.position = temp;
        }
    }

    public static void ToggleFollowStatic()
    {
        enableFollow = !enableFollow;
    }

    public void ToggleFollow()
    {
        enableFollow = !enableFollow;
    }
}
