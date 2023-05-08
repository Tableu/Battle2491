using Systems.Modifiers;
using TMPro;
using UnityEngine;

public class MoneyResource : MonoBehaviour
{
    private static MoneyResource _instance;

    public static MoneyResource Instance => _instance;
    
    public int Money => _money;
    [SerializeField] private int tick = 5;
    [SerializeField] private int baseIncreaseRate;
    [SerializeField] private int startingAmount;
    [SerializeField] private TextMeshProUGUI text;
    private int _money;
    private ModifiableStat _increaseRate;
    
    private int _counter;
    
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
        _money = startingAmount;
        _increaseRate = new ModifiableStat(baseIncreaseRate);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_counter >= tick)
        {
            _money += (int) _increaseRate;
            text.text = _money.ToString();
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
}
