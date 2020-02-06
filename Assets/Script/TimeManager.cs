using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TimeManager : MonoBehaviour
{
    public delegate void AfterAction();
    public static event AfterAction OnAfterAction;

    public int maxFlowCnt;

    private int timeCnt = 0;

    public int TimeCnt
    {
        get => timeCnt;
        set
        {
            if (value.Equals(timeCnt + 1))
            {
                OnAfterAction();
                timeCnt = value;
            }
            timeCnt = value;
        }
    }

    private void Awake()
    {
        maxFlowCnt = 4;

        OnAfterAction += Yap;

        TimeCnt++;
    }

    private void Yap()
    {
        print("!!!!!!!!!!!!!!!!!1");
    }

}
