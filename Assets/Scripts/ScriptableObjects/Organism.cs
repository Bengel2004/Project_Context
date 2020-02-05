using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Organism", menuName = "ScriptableObjects/Organism", order = 1)]

public class Organism : ScriptableObject
{
    public Sprite organismSprite;
    public string organismName;

}
