using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using UnityEngine.Events;

public class ShowUI : MonoBehaviour
{
    [SerializeField]
    private UnityEvent executeEvent;
    [SerializeField]
    private KeyCode toggleKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            executeEvent.Invoke();
        }
    }
}
