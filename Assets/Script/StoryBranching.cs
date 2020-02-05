using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBranching : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> storyObjects = new List<GameObject>();
    private int currentStoryProgress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.transform.gameObject == storyObjects[currentStoryProgress])
                {
                    Debug.Log("Progress time of day!");
                    Debug.Log("You now play as this animal script");
                    GameManager.Instance.currentAnimal = hit.transform.GetComponent<Organism>();
                }
            }
        }
    }
}
