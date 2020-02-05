using System.Collections;
using UnityEngine;

public class SelectBase : MonoBehaviour
{
    private Vector2 originPos;

    [HideInInspector] public IEnumerator ICreateCoroutine = null;

    public IEnumerator ICreate(Vector2 pos)
    {
        float currentTime = 0f;
        float settingTime = .3f;

        transform.localScale = Vector3.one * 0.1f;
        originPos = transform.position;

        while (currentTime <= settingTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one * 0.1f, Vector3.one, currentTime / settingTime);
            transform.position = Vector2.Lerp(originPos, pos, currentTime / settingTime);

            currentTime += Time.smoothDeltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one;
        transform.position = pos;
    }

    private void OnDestroy()
    {
        StopCoroutine(ICreateCoroutine);
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

        ObjectManager.Inst.PresentForcusObject.SetOutLineMaterial(false);
        ObjectManager.Inst.PresentForcusObject = null;
        Destroy(gameObject);
    }
}
