using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sun : MonoBehaviour
{
    private const int m_MaxSunAngle = 150;
    public Image Day;
    public Image Night;

    // Start is called before the first frame update
    public void PassOneDay()
    {
        Managers.time.maxFlowCnt = 1;
        StartCoroutine(SunFlow(0, 1, 2));
    }

    public IEnumerator SunFlow(int start, int end, float t)
    {
        float timer = 0f;

        int angleUnit = GetAngleUnit(m_MaxSunAngle, Managers.time.maxFlowCnt);
        transform.parent.rotation = Quaternion.Euler(0, 0, -(angleUnit * start));


        while (timer <= t)
        {
            
            float eulerZ = Mathf.Lerp((angleUnit * start), (angleUnit * end), timer / t);

            transform.parent.rotation = Quaternion.Euler(0, 0, -eulerZ);
            transform.eulerAngles = new Vector3(0, 0, 0);

            timer += Time.smoothDeltaTime;
            yield return null;
        }

        transform.parent.rotation = Quaternion.Euler(0, 0, -(angleUnit * end));
        yield break;
    }

    private int GetAngleUnit(int maxAngle, int maxFlowCnt) { return maxAngle / maxFlowCnt; }

}
