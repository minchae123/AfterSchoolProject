using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Slider uiSldier;
    public UnityAction OnPointerDownEvent;
    public UnityAction OnPointerUpEvent;
    public UnityAction<float> OnPointerDragEvent;

    private void Awake()
    {
        uiSldier = GetComponent<Slider>();
        uiSldier.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null) OnPointerDownEvent.Invoke();
        if (OnPointerDownEvent != null) OnPointerDragEvent.Invoke(uiSldier.value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null) OnPointerUpEvent.Invoke();
        uiSldier.value = 0;

    }

    public void OnSliderValueChanged(float value)
    {
        if (OnPointerDragEvent != null) OnPointerDragEvent?.Invoke(value);
    }

    public void OnDestroy()
    {
        uiSldier.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}
