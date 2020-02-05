using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject cameraFollow;
    [SerializeField]
    private Sprite[] plantSprites = new Sprite[5];
    [SerializeField]
    private int spriteCount;

    private SpriteRenderer thisSprite;

    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 temp = new Vector3(ray.origin.x, ray.origin.y, 0f);
        cameraFollow.transform.position = temp;

        if (Input.GetKeyDown(KeyCode.L))
        {
            // level up debug
            Debug.Log("Level Up!");
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        spriteCount++;
        if(spriteCount < plantSprites.Length)
            thisSprite.sprite = plantSprites[spriteCount];
    }

    private void ResetLevel()
    {
        spriteCount = 0;
        thisSprite.sprite = plantSprites[spriteCount];
    }
}
