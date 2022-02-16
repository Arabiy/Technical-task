using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public int PlayerEnergyCount { get; private set; }

    [SerializeField] private GameObject energyPanel;  //в ином случаи создал бы отдельный класс отображатель
    [SerializeField] public TextMeshProUGUI text;

    public void Init(int energy)
    {
        PlayerEnergyCount = energy;

        if (energy == 0)
        {
            EnableEnergyPanel(false);
            return;
        }

        EnableEnergyPanel();
        UpdateUi();
    }
    private void EnableEnergyPanel(bool value = true)
    {
        energyPanel.SetActive(value);
    }

    public void OnBonusUsed()
    {
        PlayerEnergyCount--;
        UpdateUi();
    }
    private void UpdateUi()
    {
        text.text = PlayerEnergyCount.ToString();
    }

    #region OnEnable & OnDisable
    private void OnEnable()
    {
        IncreaeSnape.BonusUsedEv += OnBonusUsed;
        ReducingSnape.BonusUsedEv += OnBonusUsed;
    }
    private void OnDisable()
    {
        IncreaeSnape.BonusUsedEv -= OnBonusUsed;
        ReducingSnape.BonusUsedEv -= OnBonusUsed;
    }
    #endregion
}
