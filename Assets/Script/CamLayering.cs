using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLayering : MonoBehaviour
{
    private Transform cam;
    private Vector2 thisPos;
    [SerializeField]
    private float divider = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        thisPos = new Vector3(cam.transform.position.x, transform.position.y);
        thisPos.x = thisPos.x / divider;
        this.transform.position = thisPos;
    }
}
