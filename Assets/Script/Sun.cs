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

    public void ResetDay()
    {
        Color _color = Day.color;
        _color.a = 0;
        Day.color = _color;
        Night.color = _color;
    }

    public IEnumerator SunFlow(int start, int end, float t)
    {
        float timer = 0f;

        int angleUnit = GetAngleUnit(m_MaxSunAngle, Managers.time.maxFlowCnt);
        transform.parent.rotation = Quaternion.Euler(0, 0, -(angleUnit * start));


        while (timer <= t)
        {
            if (start > (end / 4))
            {
                Color _color = Day.color;
                _color.a = Mathf.Lerp(0, 100, timer / t);
                Day.color = _color;
            }
            if (start > (end / 4))
            {
                Color _color = Night.color;
                _color.a = Mathf.Lerp(0, 100, timer / t);
                Night.color = _color;
            }


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
