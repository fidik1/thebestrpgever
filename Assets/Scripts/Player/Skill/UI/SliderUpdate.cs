using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderUpdate : MonoBehaviour
{
    Slider reloadSlider;
    public Skill skill;
    

    void Start()
    {
        reloadSlider = GetComponent<Slider>();
    }

    void Update()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        if (!skill.attribute.onCooldown)
            return;
        
        skill.attribute.timePassed += Time.deltaTime;
        reloadSlider.value = reloadSlider.maxValue - skill.attribute.timePassed / skill.attribute.cooldown;
    }
}
