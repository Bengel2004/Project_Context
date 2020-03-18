using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private Sprite[] plantSprites = new Sprite[5];
    [SerializeField]
    private int spriteCount;
    // Start is called before the first frame update

    private SpriteRenderer thisSprite;
    [SerializeField]
    private Image thisSpriteUI;

    private void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        if (Managers.Game.plantLevel < plantSprites.Length)
        {
            thisSprite.sprite = plantSprites[Managers.Game.plantLevel];
            thisSpriteUI.sprite = plantSprites[Managers.Game.plantLevel];
        }
    }
    public void Grow()
    {
        Managers.Game.plantLevel++;
        if (Managers.Game.plantLevel < plantSprites.Length)
        {
            thisSprite.sprite = plantSprites[Managers.Game.plantLevel];
            thisSpriteUI.sprite = plantSprites[Managers.Game.plantLevel];

        }
        else
        {
            // change scene maybe???
        }
    }
}
