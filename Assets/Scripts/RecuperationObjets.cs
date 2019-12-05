using UnityEngine;
using UnityEngine.UI;

public class RecuperationObjets : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;

    // Carte 1
    GameObject virus;
    GameObject splash;
    GameObject diamond;
    GameObject squeletteViolet;
    GameObject tornade;
    GameObject beryl;

    // Carte 2
    GameObject batsCloud;
    GameObject fireShield;
    GameObject electricityBall;
    GameObject electricAir;
    GameObject greenStar;
    GameObject pouf;
    GameObject darkMagicAura;

    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";

        //Carte 1
        virus = GameObject.Find("CFX_Virus").gameObject;
        splash = GameObject.Find("Big_Splash").gameObject;
        diamond = GameObject.Find("Diamond").gameObject;
        squeletteViolet = GameObject.Find("DeathSkull").gameObject;
        tornade = GameObject.Find("Tornado").gameObject;
        beryl = GameObject.Find("Etoile").gameObject;
        virus.SetActive(false);
        splash.SetActive(false);
        diamond.SetActive(false);
        squeletteViolet.SetActive(false);
        tornade.SetActive(false);
        beryl.SetActive(false);

        //Carte 2
        batsCloud = GameObject.Find("BatsCloud").gameObject;
        batsCloud.SetActive(false);
        fireShield = GameObject.Find("FireShield").gameObject;
        fireShield.SetActive(false);
        electricityBall = GameObject.Find("ElectricityBall").gameObject;
        electricityBall.SetActive(false);
        electricAir = GameObject.Find("ElectricAir").gameObject;
        electricAir.SetActive(false);
        greenStar = GameObject.Find("GreenStar").gameObject;
        greenStar.SetActive(false);
        darkMagicAura = GameObject.Find("DarkMagicAura").gameObject;
        darkMagicAura.SetActive(false);
        pouf = GameObject.Find("Pouf").gameObject;
        pouf.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
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
            if (other.gameObject.name == "elixirBleu")
            {
                splash.SetActive(true);
            }
            if (other.gameObject.name == "béryl")
            {
                beryl.SetActive(true);
            }
            else if (other.gameObject.name == "Hannya")
            {
                fireShield.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Like") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            winText.text = "+1";
            SetCountText();
            if (other.gameObject.name == "emeraude")
            {
                diamond.SetActive(true);
            }
            else if (other.gameObject.name == "fantome")
            {
                tornade.SetActive(true);
            }
            else if (other.gameObject.name == "fantome2")
            {
                electricityBall.SetActive(true);
            }
            else if (other.gameObject.name == "blueCane")
            {
                electricAir.SetActive(true);
            }
            else if (other.gameObject.name == "greenCane")
            {
                greenStar.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Angry") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            winText.text = "-1";
            SetCountText();
            if (other.gameObject.name == "tete_de_mort")
            {
                virus.SetActive(true);
            }
            else if (other.gameObject.name == "elixir_malef")
            {
                squeletteViolet.SetActive(true);
            }
            else if (other.gameObject.name == "Mannequin_Reine_Vampires")
            {
                batsCloud.SetActive(true);
            }
            else if (other.gameObject.name == "orangeCane")
            {
                pouf.SetActive(true);
            }
            else if (other.gameObject.name == "purpleCane")
            {
                darkMagicAura.SetActive(true);
            }
        }

    }

}
