using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<StoryItem> item = new List<StoryItem>();

    [SerializeField]
    private bool isLastItem;

    [SerializeField]
    private bool skipDayItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!skipDayItem) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    foreach(StoryItem i in item)
                    {
                        if(hit.transform.gameObject == i.gameObject)
                        {
                            this.enabled = false;
                            // execute event of the day.
                            i.enabled = true;
                        }
                    }
                }
            }
        }
    }
}
