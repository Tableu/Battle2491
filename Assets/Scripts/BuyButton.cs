using Ships.DataManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Color ReloadColor;

    [SerializeField] private Image shipIcon;
    [SerializeField] private Image background;
    [SerializeField] private Slider reloadBar;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ShipData shipData;

    private bool isReloading;
    private float fillTime;
    // Start is called before the first frame update
    void Start()
    {
        isReloading = false;
        reloadBar.maxValue = shipData.BuyCooldown;
        reloadBar.value = reloadBar.minValue;
        button.onClick.AddListener(OnClick);
        text.text = shipData.Cost.ToString();
        shipIcon.sprite = shipData.ShopIcon;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            reloadBar.value += Time.deltaTime;
            if (reloadBar.value >= reloadBar.maxValue)
            {
                shipIcon.color = Color.white;
                background.color = Color.white;
                reloadBar.value = reloadBar.minValue;
                reloadBar.gameObject.SetActive(false);
                isReloading = false;
                button.interactable = true;
                text.gameObject.SetActive(true);
            }
        }
    }

    private void OnClick()
    {
        if (!MoneyResource.Instance.UseMoney(shipData.Cost))
        {
            return;
        }

        shipIcon.color = ReloadColor;
        background.color = ReloadColor;
        button.interactable = false;
        reloadBar.gameObject.SetActive(true);
        isReloading = true;
        text.gameObject.SetActive(false);
        GlobalReferences.Instance.TurretManager.SpawnShip(shipData,
            GlobalReferences.Instance.TurretManager.transform.position + new Vector3(0,shipData.RotateRange,0));
    }
}
