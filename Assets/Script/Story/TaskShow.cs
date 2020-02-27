using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskShow : MonoBehaviour
{

    public bool isFinished = false;
    public TextMeshProUGUI task;
    public Image taskStatus;
    public Sprite finishedSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FinishTask()
    {
        isFinished = true;
        taskStatus.sprite = finishedSprite;
    }

}
