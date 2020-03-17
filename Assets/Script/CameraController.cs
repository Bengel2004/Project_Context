using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cameraFollow;
    public static bool enableFollow = true;

    [SerializeField]
    private Vector2 bounds;

    // Update is called once per frame
    void Update()
    {
        if (enableFollow)
        {
            //if(GameManager.Instance.currentAnimal == thisOrganism)
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 _temp = new Vector3(_ray.origin.x, _ray.origin.y, 0f);
            cameraFollow.transform.position = _temp;
            /*
            if(_temp.x > bounds.x || _temp.x < -bounds.x)
            {
                Debug.LogError("true");
                Vector3 _tempVector = _temp;
                _tempVector = -_tempVector;
                cameraFollow.transform.position = _tempVector;

            } 
            */
        }
        Debug.Log(enableFollow);
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
