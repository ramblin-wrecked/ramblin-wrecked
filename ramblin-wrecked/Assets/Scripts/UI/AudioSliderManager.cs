using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class AudioSliderManager : MonoBehaviour
{

    Slider slider;
    public bool bg;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnChangedValue()
    {
        if (bg)
            OptionsManager.bgVolume = slider.value;
        else
            OptionsManager.sfxVolume = slider.value;
    }

}
