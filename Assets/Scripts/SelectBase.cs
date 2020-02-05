using System.Collections;
using UnityEngine;

public class SelectBase : MonoBehaviour
{
    private Vector2 originPos;

    public IEnumerator ICreate(Vector2 pos)
    {
        float currentTime = 0f;
        float settingTime = .2f;

        transform.localScale = Vector3.one * 0.1f;
        originPos = transform.position;

        while(currentTime <= settingTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one * 0.1f, Vector3.one, currentTime / settingTime);
            transform.position = Vector2.Lerp(originPos, pos, currentTime / settingTime);
            
            currentTime += Time.smoothDeltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one;
        transform.position = pos;
    }

    public IEnumerator IDestroy()
    {
        float currentTime = 0f;
        float settingTime = 0.5f;

        transform.localScale = Vector3.one;
        Vector2 oldPos = transform.position;

        while (currentTime <= settingTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, currentTime / settingTime);
            transform.position = Vector2.Lerp(oldPos, originPos, currentTime / settingTime);

            currentTime += Time.smoothDeltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        transform.position = originPos;

        Managers.Out.PresentForcusObject.SetOutLineMaterial(false);
        Managers.Out.PresentForcusObject = null;
        Destroy(gameObject);
    }
}
