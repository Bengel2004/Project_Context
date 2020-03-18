using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using TMPro;
using UnityEngine.Events;

public class StoryItem : MonoBehaviour
{
    [Header("Main Tree")]
    // Start is called before the first frame update
    [SerializeField]
    private List<StoryItem> item = new List<StoryItem>();
    public string task;
    public AudioClip clip;

    [Header("Day Settings")]
    [SerializeField]
    private bool isLastItem;
    [SerializeField]
    private bool skipDayItem;


    [SerializeField]
    private int currentSunPos;
    [SerializeField]
    private int DaySunPos;
    private Sun sun;

    [SerializeField]
    private OrganismObj organism;
    [SerializeField]
    private NarrativeItem narItem;

    private Button growButton;
    private TaskShow taskItem;


    [SerializeField]
    public bool showText;
    [HideInInspector] // maak if else editore xtension als isLastItem true is dan laat hij dit zien;
    public string endOfDayText;  // Delete deze later
    [SerializeField]
    private UIView infoView;
    [SerializeField]
    private TextMeshProUGUI infoViewText;

    [Header("Events")]
    [SerializeField]
    public bool startEventBool;
    public UnityEvent startEvent;
    [SerializeField]
    public bool endEventBool;
    public UnityEvent endEvent;

    [SerializeField]
    public bool altBehaviour;
    public UnityEvent eventType;

    private Outline thisOutline;

    private void Awake()
    {

        if (showText)
            growButton = GameObject.Find("UIGrowButton")?.GetComponent<Button>();

        if (showText && enabled)
        {
            Debug.Log("test", gameObject);
            Managers.Narrative.NewNarrative(narItem);
        }
    }
    private void OnEnable()
    {
        foreach (StoryItem i in item)
        {
            OutLine _temp = i.GetComponent<OutLine>();
            if(_temp != null)
            {
                _temp.showOutline = true;
            }
        }



        if (showText && enabled)
        {
            Debug.Log("test", gameObject);
            Managers.Narrative.NewNarrative(narItem);
        }
        if(startEventBool && enabled)
        {
            startEvent.Invoke();
        }

        //ShowOrganism.Instance.ShowImage(organism);
        Debug.Log(gameObject.name);
        sun = FindObjectOfType<Sun>();
        taskItem = Managers.Story.CreateTaskItem(task);

        if (currentSunPos == 0)
        {
            if (sun != null)
                sun.ResetDay();
        }

        if (skipDayItem)
        {
            growButton = GameObject.Find("UIGrowButton")?.GetComponent<Button>();
            growButton?.onClick.AddListener(ButtonTask);
            growButton?.onClick.AddListener(PassTime);
        }
    }
    private void OnDisable()
    {
        foreach (StoryItem i in item)
        {
            OutLine _temp = i.GetComponent<OutLine>();
            if (_temp != null)
            {
                _temp.showOutline = false;
            }
        }

        if (skipDayItem)
        {
            growButton?.onClick.RemoveListener(ButtonTask);
            growButton?.onClick.RemoveListener(PassTime);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Managers.Narrative.isReading)
        {
            if (!skipDayItem)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        foreach (StoryItem i in item)
                        {
                            if (hit.transform.gameObject == i.gameObject)
                            {
                                if (i.clip != null)
                                {
                                    Managers.AudioPlayer.source.PlayOneShot(i.clip);
                                }
                                if (i.altBehaviour)
                                {
                                    i.eventType.Invoke();
                                }
                                else
                                {
                                    CompleteTask(i);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (growButton == null)
                {
                    growButton = GameObject.Find("UIGrowButton")?.GetComponent<Button>();
                    growButton?.onClick.AddListener(ButtonTask);
                    growButton?.onClick.AddListener(PassTime);
                }
            }
        }
    }

    private void PassTime()
    {
        Managers.time.maxFlowCnt = DaySunPos;
        sun.StartCoroutine(sun.SunFlow(currentSunPos, (currentSunPos + 1), 2));
    }

    public void CompleteTask(StoryItem _storyItem)
    {
        if (endEventBool)
        {
            endEvent.Invoke();
        }
        
        this.enabled = false;
        PassTime();
        _storyItem.enabled = true;
        taskItem.FinishTask();
        Destroy(taskItem.gameObject);

        
    }

    public void ButtonTask()
    {
        CompleteTask(item[0]);
        Managers.Story.view.Hide();
    }
}
