using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerController playerController;

    public Text textXp;
    public Text textHealth;
    public Text textMana;

    public Slider xpBar;
    public Slider healthBar;
    public Slider manaBar;

    void Update()
    {
        textXp.text = playerController.lvl.ToString() + " LEVEL";
        textHealth.text = playerController.hp.ToString() + " / " + playerController.maxHp.ToString();
        textMana.text = playerController.mana.ToString() + " / " + playerController.maxMana.ToString();

        xpBar.maxValue = playerController.targetXp;
        xpBar.value = playerController.xp;
        
        healthBar.maxValue = playerController.maxHp;
        healthBar.value = playerController.hp;

        manaBar.maxValue = playerController.maxMana;
        manaBar.value = playerController.mana;
    }
}
