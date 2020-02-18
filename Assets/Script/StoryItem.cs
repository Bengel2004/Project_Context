using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<StoryBranch> item = new List<StoryBranch>();

    [SerializeField]
    private bool isLastStoryItem;

    [SerializeField]
    private bool skipDayItem;

    public int currentDay = 0;
    public int endOfDay = 1;


    private Button growButton;
    void Start()
    {
        growButton = GameObject.Find("UIButtonGrow").GetComponent<Button>();        
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
                    foreach(StoryBranch i in item)
                    {
                        if(hit.transform.gameObject == i.item.gameObject)
                        {
                            Managers.Game.currentAnimal = hit.transform.GetComponent<Organism>();
                            CameraController.ToggleFollowStatic();
                            // chosenAnimal.sprite = lastClicked.thisOrganism.organismSprite;
                            // maak een manager voor dit soort stats

                            this.enabled = false;
                            // execute event of the day.
                            OnNextDay(i.item);
                            i.item.enabled = true;
                        }
                    }
                }
            }
        }
    }

    void OnNextDay(StoryItem _i)
    {
        // werk dit nog ff beter uit
        growButton.onClick.RemoveListener(_i.GrowButtonFunc);
        growButton.onClick.AddListener(GrowButtonFunc);


        // Voer hier de on next day event uit.
        // Verwijder de addlistener van de knop
        // voeg de nieuwe addlistener toe
    }

    public void GrowButtonFunc()
    {

    }


}


[System.Serializable]
public class StoryBranch
{
    public string currentBranchName;
    public StoryItem item;

    [TextArea]
    public string _storyText; // hack
}