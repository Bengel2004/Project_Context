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
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private UIView view;
    [SerializeField]
    private Image personImg;
    [SerializeField]
    private TextMeshProUGUI personText;
    [SerializeField]
    private GameObject wateringSprite;
    [SerializeField]
    private GameObject showJuan;

    public bool isReading = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if(source == null)
        {
            source = GetComponent<AudioSource>();
        }
        showJuan.SetActive(false);
        wateringSprite.SetActive(false);
    }

    void Update()
    {
        
    }

    public void NewNarrative(NarrativeItem _narItem)
    {
        CameraController.ToggleFollowStatic();
        view.Show();
        currentText = 0;
        isReading = true;
        narItem = _narItem;
        personText.text = narItem.narrativeObj[currentText].narrativeText;
        personImg.sprite = narItem.narrativeObj[currentText].narrativePerson;

        if (narItem.narrativeObj[currentText].showJuan)
        {
            Debug.Log("JUAN SHOW UR BOOTY");
            showJuan.SetActive(true);
        }
        else
        {
            showJuan.SetActive(false);
        }
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
                Debug.Log("Play Audio");
                source.PlayOneShot(narItem.narrativeObj[currentText].clip);
            }
            if (narItem.narrativeObj[currentText].showWater)
            {
                wateringSprite.SetActive(true);
            }
            else
            {
                wateringSprite.SetActive(false);
            }

            if (narItem.narrativeObj[currentText].showJuan)
            {
                Debug.Log("JUAN SHOW UR BOOTY");
                showJuan.SetActive(true);
            }
            else
            {
                showJuan.SetActive(false);
            }
        }
        else
        {
            isReading = false;
            view.Hide();
            CameraController.ToggleFollowStatic();
         //   storItem.endEvent.Invoke();
        }
    }
}
