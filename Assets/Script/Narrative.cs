using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using UnityEngine.UI;
using TMPro;

public class Narrative : MonoBehaviour
{
    private int currentText;
    private NarrativeItem narItem;
    private AudioSource source;

    [SerializeField]
    private UIView view;
    [SerializeField]
    private Image personImg;
    [SerializeField]
    private TextMeshProUGUI personText;


    public bool isReading = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewNarrative(NarrativeItem _narItem)
    {
        view.Show();
        currentText = 0;
        isReading = true;
        narItem = _narItem;

        personText.text = narItem.narrativeObj[currentText].narrativeText;
        personImg.sprite = narItem.narrativeObj[currentText].narrativePerson;
    }

    public void SkipText()
    {
        currentText++;
        if (currentText < narItem.narrativeObj.Count)
        {
            personText.text = narItem.narrativeObj[currentText].narrativeText;
            personImg.sprite = narItem.narrativeObj[currentText].narrativePerson;
            if(narItem.narrativeObj[currentText].clip != null)
            {
                source.PlayOneShot(narItem.narrativeObj[currentText].clip);
            }
        }
        else
        {
            isReading = false;
            view.Hide();
         //   storItem.endEvent.Invoke();
        }
    }
}
