using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowOrganism : MonoBehaviour
{
    [SerializeField]
    private Image animalImg;
    // Start is called before the first frame update

    public static ShowOrganism Instance;

    void Awake()
    {
        //Check if there is already an instance of Singleton_Controller
        if (Instance == null)
        {
            //if not, set it to this.
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //If instance already exists
        else if (Instance != this && Instance != null)
        {
            //Destroy this, this applies our singleton pattern so there can only be one instance of Singleton_Controller.
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowImage(OrganismObj _organism)
    {
        animalImg.sprite = _organism.organismSprite;
    }
}
