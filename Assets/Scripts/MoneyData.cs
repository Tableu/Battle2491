using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyData", menuName = "Resources/MoneyData")]
[Serializable]
public class MoneyData : UniqueId
{
    [SerializeField] private List<ResourceLevel> upgrades;
    [SerializeField] private int startingAmount;

    public List<ResourceLevel> Upgrades => upgrades;
    public int StartingAmount => startingAmount;
}

[Serializable]
public struct ResourceLevel
{
    public int Rate;
    public int Max;
    public int UpgradeCost;
    public bool LastLevel;
}