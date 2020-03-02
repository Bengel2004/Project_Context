using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectManager))]
[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(TimeManager))]
[RequireComponent(typeof(StoryBranching))]
[DefaultExecutionOrder(-1)]
public class Managers : MonoBehaviour
{
    public static Managers Inst = null;

    public static ObjectManager Object = null;
    public static GameManager Game = null;
    public static TimeManager time = null;
    public static StoryBranching Story = null;

    private void Awake()
    {
        #region Make Singleton

        if (Inst != null)
            Destroy(Inst);

        Inst = this;

        #endregion


        #region Manger's Parsing
        
        Object = GetComponent<ObjectManager>();
        Game = GetComponent<GameManager>();
        time = GetComponent<TimeManager>();
        Story = GetComponent<StoryBranching>();

        #endregion

    }
}
