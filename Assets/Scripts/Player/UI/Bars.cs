using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    [SerializeField] Stats stats;

    [SerializeField] Text textXp;
    [SerializeField] Text textHealth;
    [SerializeField] Text textMana;

    [SerializeField] Slider xpBar;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider manaBar;

    void Start()
    {
        Stats.ChangedHP += UpdateHealthBar;
        Stats.ChangedMana += UpdateManaBar;
        Stats.ChangedXP += UpdateXpBar;
    }

    public void UpdateHealthBar()
    {
        textHealth.text = stats.hp.ToString() + " / " + stats.maxHp.ToString();
        healthBar.maxValue = stats.maxHp;
        healthBar.value = stats.hp;
    }

    public void UpdateManaBar()
    {
        textMana.text = stats.mana.ToString() + " / " + stats.maxMana.ToString();
        manaBar.maxValue = stats.maxMana;
        manaBar.value = stats.mana;
    }

    public void UpdateXpBar()
    {
        textXp.text = stats.lvl.ToString() + " LEVEL";
        xpBar.maxValue = stats.targetXp;
        xpBar.value = stats.xp;
    }
}
