using Systems.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyResource : MonoBehaviour
{
    private static MoneyResource _instance;

    public static MoneyResource Instance => _instance;
    
    public int Money => _money;
    public MoneyData MoneyData => moneyData;
    public int Level => _level;

    [SerializeField] private int tick = 5;
    [SerializeField] private MoneyData moneyData;
    [FormerlySerializedAs("text")] [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI upgradeText;
    private int _money;
    private ModifiableStat _increaseRate;
    
    private int _counter;
    private int _level = 0;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    private void Start()
    {
        _money = moneyData.StartingAmount;
        _increaseRate = new ModifiableStat(moneyData.Upgrades[_level].Rate);
        upgradeText.text = moneyData.Upgrades[_level].UpgradeCost.ToString();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_counter >= tick)
        {
            _money += (int) _increaseRate;
            moneyText.text = _money.ToString()+'/'+moneyData.Upgrades[_level].Max.ToString();
            _counter = 0;
        }

        _counter++;
    }

    public bool UseMoney(int amount)
    {
        if (_money - amount >= 0)
        {
            _money -= amount;
            return true;
        }
        return false;
    }

    public void Upgrade()
    {
        if (moneyData.Upgrades[_level].LastLevel)
        {
            upgradeText.text = "MAX";
            return;
        }
        int upgradeCost = moneyData.Upgrades[_level].UpgradeCost;
        if (_money >= upgradeCost)
        {
            _money -= upgradeCost;
            _level++;
            if (moneyData.Upgrades[_level].LastLevel)
            {
                upgradeText.text = "MAX";
            }
            else
            {
                upgradeText.text = moneyData.Upgrades[_level].UpgradeCost.ToString();
            }
        }
    }
}
