using UnityEngine;

public class HideEnemy : MonoBehaviour
{
    private int counter;
    public bool HideAtStart;
    public GameObject Visuals;

    void Start()
    {
        Visuals.SetActive(!HideAtStart);
        counter = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        counter++;
        Visuals.SetActive(counter > 0);
        Debug.Log("check");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        counter--;
        Visuals.SetActive(counter > 0);
    }
}
