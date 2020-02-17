using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using UnityEngine.UI;
using TMPro;

public class StoryBranching : MonoBehaviour
{
    [SerializeField]
    public List<StoryBranch> storyBranch;
    [SerializeField]
    private int currentStoryBranch = 0;
  //  private int currentStoryProgress;

    [SerializeField]
    private UIView growView;

    [SerializeField]
    private UIView popUpOrganism;
    [SerializeField]
    private Image chosenAnimal;

    private Organism lastClicked;

    private Sun sun;

    [SerializeField] // hack
    private TextMeshProUGUI storyText;
    [SerializeField] //hack
    private UIView storyUI;

    private void Start()
    {
        sun = FindObjectOfType<Sun>();
        storyText.text = storyBranch[currentStoryBranch]._storyText; // hack
    }
    // Update is called once per frame
    private void Update()
    {
        if (currentStoryBranch < storyBranch.Count)
        {
            if (!storyBranch[currentStoryBranch].JustGrowDay)
            {
                StopAllCoroutines();
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null)
                    {
                        if (hit.transform.gameObject == storyBranch[currentStoryBranch].branch[storyBranch[currentStoryBranch].currentBranchProgress])
                        {
                            //storyBranch[currentStoryBranch].currentBranchProgress++;
                            // Managers.Game.currentAnimal = hit.transform.GetComponent<Organism>();
                            popUpOrganism.Show();
                            CameraController.ToggleFollowStatic();
                            lastClicked = hit.transform.GetComponent<Organism>();
                            chosenAnimal.sprite = lastClicked.thisOrganism.organismSprite;
                        }
                    }
                }

                if (storyBranch[currentStoryBranch].currentBranchProgress == storyBranch[currentStoryBranch].branch.Count)
                {
                    //  updateStoryProgress();
                    growView.Show();
                }
            }
            else
            {
                if (!growView.gameObject.activeSelf)
                {
                    ShowPlant();
                }
            }
        }
    }
    private IEnumerator ShowUiView()
    {
        if (storyBranch[currentStoryBranch].JustGrowDay)
        {
            yield return new WaitForSeconds(2);
            growView.Show();
        }
    }

 

    public void ChooseAnimal()
    {
        CameraController.ToggleFollowStatic();
        storyBranch[currentStoryBranch].currentBranchProgress++;
        Managers.Game.currentAnimal = lastClicked;
        Debug.Log("Progress time of day!");
        Debug.Log("You now play as this animal script");
        PassTime();
    }

    public void PassTime()
    {
        Managers.time.maxFlowCnt = storyBranch[currentStoryBranch].endOfDay;
        sun.StartCoroutine(sun.SunFlow(storyBranch[currentStoryBranch].currentDay, (storyBranch[currentStoryBranch].currentDay + 1), 2));
        storyBranch[currentStoryBranch].currentDay++;
    }

    public void ShowPlant()
    {
        // if(Managers.Game.plantLevel < storyBranch[currentStoryBranch].standardGrow)
        //  {
        if (currentStoryBranch < storyBranch.Count)
            StartCoroutine(ShowUiView());
     //   }
    }

    public void updateStoryProgress()
    {
        currentStoryBranch++;
        storyUI.Show(); // hack
        storyText.text = storyBranch[currentStoryBranch]._storyText; // hack
    }

}

[System.Serializable]
public class StoryBranch
{
    public string currentBranchName;
    public bool JustGrowDay = false;
    public List<GameObject> branch;
    public int currentBranchProgress = 0;
    public int standardGrow = 1;
    public int currentDay = 0;
    public int endOfDay = 1;

    [TextArea]
    public string _storyText; // hack
}