using UnityEngine;
using UnityEngine.UI;

public class RecuperationObjets : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;
    GameObject virus;
    GameObject splash;
    GameObject diamond;

    private void Start()
    {
        virus = GameObject.Find("CFX_Virus").gameObject;
        splash = GameObject.Find("Big_Splash").gameObject;
        diamond = GameObject.Find("Diamond").gameObject;
        virus.SetActive(false);
        splash.SetActive(false);
        diamond.SetActive(false);
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!";
            Time.timeScale = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Love") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            winText.text = "+2";
            SetCountText();
            splash.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Like") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            winText.text = "+1";
            SetCountText();
            diamond.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Angry") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            winText.text = "-1";
            SetCountText();
            virus.SetActive(true);
        }

    }

}
