using Ships.DataManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Color ReloadColor;

    [SerializeField] private Image[] images;
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
        reloadBar.value = reloadBar.minValue;
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            reloadBar.value += Time.deltaTime;
            if (reloadBar.value >= reloadBar.maxValue)
            {
                foreach (var image in images)
                {
                    image.color = Color.white;
                }
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
        foreach (var image in images)
        {
            image.color = ReloadColor;
        }

        button.interactable = false;
        reloadBar.gameObject.SetActive(true);
        isReloading = true;
        text.gameObject.SetActive(false);
        GlobalReferences.Instance.TurretManager.SpawnShip(shipData,
            GlobalReferences.Instance.TurretManager.transform.position + new Vector3(1,1,0));
    }
}
