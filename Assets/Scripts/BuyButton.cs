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

    private bool isReloading;
    private float fillTime;
    // Start is called before the first frame update
    void Start()
    {
        isReloading = false;
        fillTime = 0f;
        reloadBar.value = reloadBar.minValue;
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            reloadBar.value = Mathf.Lerp(reloadBar.minValue, reloadBar.maxValue, fillTime);
            fillTime += 0.375f * Time.deltaTime;
            if (reloadBar.value >= reloadBar.maxValue)
            {
                foreach (var image in images)
                {
                    image.color = Color.white;
                }
                reloadBar.value = reloadBar.minValue;
                reloadBar.gameObject.SetActive(false);
                fillTime = 0f;
                isReloading = false;
                button.interactable = true;
                text.gameObject.SetActive(true);
            }
        }
    }

    private void OnClick()
    {
        Debug.Log("clicked");
        foreach (var image in images)
        {
            image.color = ReloadColor;
        }

        button.interactable = false;
        reloadBar.gameObject.SetActive(true);
        isReloading = true;
        text.gameObject.SetActive(false);
    }
}
