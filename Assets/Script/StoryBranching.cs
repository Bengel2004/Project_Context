using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class StoryBranching : MonoBehaviour
{
    [SerializeField]
    public List<StoryBranch> storyBranch;
    [SerializeField]
    private int currentStoryBranch = 0;
  //  private int currentStoryProgress;

    [SerializeField]
    private UIView view;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.plantLevel == storyBranch[currentStoryBranch].standardGrow)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject == storyBranch[currentStoryBranch].branch[storyBranch[currentStoryBranch].currentBranchProgress])
                    {
                        storyBranch[currentStoryBranch].currentBranchProgress++;
                        Debug.Log("Progress time of day!");
                        Debug.Log("You now play as this animal script");
                        GameManager.Instance.currentAnimal = hit.transform.GetComponent<Organism>();
                    }
                }
            }

            if (storyBranch[currentStoryBranch].currentBranchProgress == storyBranch[currentStoryBranch].branch.Count)
            {
                updateStoryProgress();
                view.Show();
            }
        }
    }

    public void ShowPlant()
    {
        if(GameManager.Instance.plantLevel < storyBranch[currentStoryBranch].standardGrow)
        {
            StartCoroutine(ShowUiView());
        }
    }

    IEnumerator ShowUiView()
    {
        yield return new WaitForSeconds(2);
        view.Show();
    }

    public void updateStoryProgress()
    {
        currentStoryBranch++;
    }

}
[System.Serializable]
public class StoryBranch
{
    public string currentBranchName;
    public List<GameObject> branch;
    public int currentBranchProgress = 0;
    public int standardGrow = 1;
    public int endOfDay = 1;
}