using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    [SerializeField] Player player;

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
        textHealth.text = player.hp.ToString() + " / " + player.maxHp.ToString();
        healthBar.maxValue = player.maxHp;
        healthBar.value = player.hp;
    }

    public void UpdateManaBar()
    {
        textMana.text = player.mana.ToString() + " / " + player.maxMana.ToString();
        manaBar.maxValue = player.maxMana;
        manaBar.value = player.mana;
    }

    public void UpdateXpBar()
    {
        textXp.text = player.lvl.ToString() + " LEVEL";
        xpBar.maxValue = player.targetXp;
        xpBar.value = player.xp;
    }
}
