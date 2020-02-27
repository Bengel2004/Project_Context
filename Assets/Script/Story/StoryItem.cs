using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<StoryItem> item = new List<StoryItem>();
    public string task;

    [SerializeField]
    private bool isLastItem;
    [SerializeField]
    private bool skipDayItem;

    [SerializeField]
    private int currentSunPos;
    [SerializeField]
    private int DaySunPos;
    private Sun sun;
    
    private Button growButton;
    private TaskShow taskItem;
    private void OnEnable()
    {
        sun = FindObjectOfType<Sun>();
        if (skipDayItem)
        {
            Managers.Story.view.Show();
            growButton = GameObject.Find("UIGrowButton").GetComponent<Button>();
            growButton.onClick.AddListener(ButtonTask);
            growButton.onClick.AddListener(PassTime);
        }

        taskItem = Managers.Story.CreateTaskItem(task);
    }
    private void OnDisable()
    {
        if (skipDayItem)
        {
            growButton.onClick.RemoveListener(ButtonTask);
            growButton.onClick.RemoveListener(PassTime);
        }
    }

    // Update is called once per frame
    private void Update()
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
                            CompleteTask(i);
                        }
                    }
                }
            }
        }
    }

    private void PassTime()
    {
        Managers.time.maxFlowCnt = DaySunPos;
        sun.StartCoroutine(sun.SunFlow(currentSunPos, (currentSunPos + 1), 2));
    }

    private void CompleteTask(StoryItem _storyItem)
    {
        this.enabled = false;
        PassTime();
        _storyItem.enabled = true;
        taskItem.FinishTask();
    }

    public void ButtonTask()
    {
        CompleteTask(item[0]);
        Managers.Story.view.Hide();
    }
}
