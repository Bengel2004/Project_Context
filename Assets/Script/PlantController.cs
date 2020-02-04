using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector2 minDeadZone;
    [SerializeField]
    private Vector2 maxDeadZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //   if(ray.origin.x > minDeadZone.x && ray.origin.y > minDeadZone.y && ray.origin.x < maxDeadZone.x && ray.origin.y < maxDeadZone.y)
        Vector3 temp = new Vector3(ray.origin.x, ray.origin.y, 0f);
        transform.position = temp;
    }
}
