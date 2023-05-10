using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndPopup : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private TextMeshProUGUI buttonText1;
    [SerializeField] private Button button2;
    [SerializeField] private TextMeshProUGUI buttonText2;
    [SerializeField] private TextMeshProUGUI titleText;
    public void Initialize(LevelEndPopupType type)
    {
        switch (type)
        {
            case LevelEndPopupType.Continue:
                buttonText1.text = "Continue";
                buttonText2.text = "Quit";
                titleText.text = "You won!";
                break;
            case LevelEndPopupType.Death:
                buttonText1.text = "Restart";
                buttonText2.text = "Quit";
                titleText.text = "You died";
                break;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}

public enum LevelEndPopupType
{
    Death,
    Continue
}
