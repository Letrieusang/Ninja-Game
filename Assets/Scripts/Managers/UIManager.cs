using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [Header("Stats")]
   [SerializeField] private PlayerStats stats;

   [Header("Bars")]
   [SerializeField] private Image healthBar;
   [SerializeField] private Image manaBar;
   [SerializeField] private Image epxBar;

   [Header("Text")]
   [SerializeField] private TextMeshProUGUI levelTmp;
   [SerializeField] private TextMeshProUGUI healthTmp;
   [SerializeField] private TextMeshProUGUI manaTmp;
   [SerializeField] private TextMeshProUGUI expTmp;

   private void Update()
   {
      updatePlayerUI();
   }

   private void updatePlayerUI()
   {
      healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, stats.Health / stats.MaxHealth, 10f * Time.deltaTime);
      manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, stats.Mana / stats.MaxMana, 10f * Time.deltaTime);
      epxBar.fillAmount = Mathf.Lerp(epxBar.fillAmount, stats.CurrentExp / stats.NextLevelExp, 10f * Time.deltaTime);
      
      levelTmp.text = $"Level {stats.Level}";
      healthTmp.text = $"{stats.Health} / {stats.MaxHealth}";
      manaTmp.text = $"{stats.Mana} / {stats.MaxMana}";
      expTmp.text = $"{stats.CurrentExp} / {stats.NextLevelExp}";
      
   }
   
}
