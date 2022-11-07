using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SliderScript : MonoBehaviour
{
    Text OptionText;
    Slider slider;
    void Awake()
    {
        OptionText = GetComponentInChildren<Text>();
        slider = GetComponent<Slider>();
        InitOption();
    }
    
    
    public void SetText(float value)
    {
        OptionText.text = $"{gameObject.name} : {value}";
    }
    private void InitOption()
    {
        slider.onValueChanged.Invoke(slider.value);
    }
}
