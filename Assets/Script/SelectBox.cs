using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SelectBox : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private int index;
    [SerializeField] [Range(0.8f, 0.9f)] private float size = 0.9f;

    private RectTransform rt;
    private Image boxImage;
    private Text boxText;

    private string originText;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();

        boxText = transform.Find("[Text]").GetComponent<Text>();
        boxImage = transform.Find("[Image]").GetComponent<Image>();

        originText = boxText.text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(transform.parent.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rt.localScale = Vector3.one;
        boxText.text = originText;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rt.localScale = Vector3.one * size;
        boxText.text = "Push!";
    }
}