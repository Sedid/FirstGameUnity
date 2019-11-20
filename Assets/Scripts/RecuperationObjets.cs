using UnityEngine;
using UnityEngine.UI;

public class RecuperationObjets : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;
    GameObject virus;
    GameObject diamond;

    private void Start()
    {
        virus = GameObject.Find("CFX_Virus").gameObject;
        diamond = GameObject.Find("CFX_PickupDiamond").gameObject;
        virus.SetActive(false);
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
        if (other.gameObject.CompareTag("Love") && Input.GetKeyDown(KeyCode.X))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            winText.text = "+2";
            SetCountText();
            
        }
        else if (other.gameObject.CompareTag("Like") && Input.GetKeyDown(KeyCode.X))
        {
            other.gameObject.SetActive(false);
            diamond.SetActive(true);
            count = count + 1;
            winText.text = "+1";
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Angry") && Input.GetKeyDown(KeyCode.X))
        {
            other.gameObject.SetActive(false);
            virus.SetActive(true);
            count = count - 1;
            winText.text = "-1";
            SetCountText();
        }

    }

}
