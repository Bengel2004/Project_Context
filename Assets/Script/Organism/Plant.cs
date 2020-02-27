using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : Organism
{
    [SerializeField]
    private Sprite[] plantSprites = new Sprite[5];
    [SerializeField]
    private int spriteCount;
    // Start is called before the first frame update

    private SpriteRenderer thisSprite;
    [SerializeField]
    private Image thisSpriteUI;

    protected override void Start()
    {
        base.Start();
        thisSprite = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.L))
        {
            // level up debug
            Debug.Log("Level Up!");
            ExecuteBehaviour();
        }

        if (Managers.Game.plantLevel < plantSprites.Length)
        {
            thisSprite.sprite = plantSprites[Managers.Game.plantLevel];
            thisSpriteUI.sprite = plantSprites[Managers.Game.plantLevel];
        }
    }
    protected override void ExecuteBehaviour()
    {
        base.ExecuteBehaviour();

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
