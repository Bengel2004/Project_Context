using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Organism
{
    [SerializeField]
    private Sprite[] plantSprites = new Sprite[5];
    [SerializeField]
    private int spriteCount;
    // Start is called before the first frame update
    private SpriteRenderer thisSprite;
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
        }
        else
        {
            // change scene maybe???
        }
    }
}
