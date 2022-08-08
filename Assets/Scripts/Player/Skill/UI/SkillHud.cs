using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHud : MonoBehaviour
{
    [SerializeField] List<Image> slotsIcons;
    [SerializeField] List<Slider> reloadSlider;

    [SerializeField] SkillController skillController;

    void Start()
    {
        for (int i = 0; i < skillController.skills.Count; i++)
        {
            slotsIcons[i].sprite = skillController.skills[i].attribute.icone;
        }

        for (int i = 0; i < skillController.skills.Count; i++)
        {
            reloadSlider[i].maxValue = 1;
            reloadSlider[i].value = 0;
            reloadSlider[i].GetComponent<SliderUpdate>().skill = skillController.skills[i];
        }
    }

    public void SetSliderValue(int sliderCount)
    {
        reloadSlider[sliderCount].value = skillController.skills[sliderCount].attribute.cooldown;
    }
}
