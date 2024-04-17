using TMPro;
using UnityEngine;

public class SliderTextReadout : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxSliderValue = 100.0f;

    public void SliderValue(float value)
    {
        float localValue = value * maxSliderValue;
        sliderText.text = localValue.ToString("0") + "%";
    }
}
