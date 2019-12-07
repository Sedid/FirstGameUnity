﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecuperationObjets : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;
    public Slider hpZombie;
    public Slider hpJoueur;
    GameObject unPoint;
    GameObject twoPoints;
    GameObject malusUnPoint;
    readonly float timer = 1f;
    GameObject victoire;
    GameObject pressZ;

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
    GameObject skullExplosion;
    GameObject darkMagic;
    GameObject disruptiveForce;
    GameObject fireEffect;
    GameObject powEffect;
    GameObject smokeEffect;
    GameObject auraBubble;
    GameObject pickupHeart;
    GameObject rockEffect;
    GameObject pickupSmiley;
    GameObject blueVirus;

    private void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
        unPoint = GameObject.Find("unPoint").gameObject;
        unPoint.SetActive(false);
        malusUnPoint = GameObject.Find("malusUnPoint").gameObject;
        malusUnPoint.SetActive(false);
        twoPoints = GameObject.Find("twoPoints").gameObject;
        twoPoints.SetActive(false);
        victoire = GameObject.Find("victoire").gameObject;
        victoire.SetActive(false);
        pressZ = GameObject.Find("pressZ").gameObject;
        pressZ.SetActive(false);


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
        skullExplosion = GameObject.Find("SkullExplosion").gameObject;
        skullExplosion.SetActive(false);
        darkMagic = GameObject.Find("DarkMagic").gameObject;
        darkMagic.SetActive(false);
        disruptiveForce = GameObject.Find("DisruptiveForce").gameObject;
        disruptiveForce.SetActive(false);
        fireEffect = GameObject.Find("FireEffect").gameObject;
        fireEffect.SetActive(false);
        powEffect = GameObject.Find("PowEffect").gameObject;
        powEffect.SetActive(false);
        smokeEffect = GameObject.Find("SmokeEffect").gameObject;
        smokeEffect.SetActive(false);
        auraBubble = GameObject.Find("AuraBubble").gameObject;
        auraBubble.SetActive(false);
        pickupHeart = GameObject.Find("PickupHeart").gameObject;
        pickupHeart.SetActive(false);
        rockEffect = GameObject.Find("RockEffect").gameObject;
        rockEffect.SetActive(false);
        pickupSmiley = GameObject.Find("PickupSmiley").gameObject;
        pickupSmiley.SetActive(false);
        blueVirus = GameObject.Find("BlueVirus").gameObject;
        blueVirus.SetActive(false);
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9 && hpZombie.value <= 0)
        {
            //winText.text = "You Win!";
            victoire.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.transform.CompareTag("Love")) || (other.transform.CompareTag("Like")) || (other.transform.CompareTag("Angry")))
        {
            pressZ.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if ((other.transform.CompareTag("Love")) || (other.transform.CompareTag("Like")) || (other.transform.CompareTag("Angry")))
        {
            pressZ.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Love") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count += 2;
            //winText.text = "+2";
            pressZ.SetActive(false);
            StartCoroutine(DeuxPoints());
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
            count += 1;
            //winText.text = "+1";
            pressZ.SetActive(false);
            StartCoroutine(UnPoint());
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
            else if (other.gameObject.name == "SkullHead")
            {
                skullExplosion.SetActive(true);
            }
            else if (other.gameObject.name == "redCane")
            {
                fireEffect.SetActive(true);
            }
            else if (other.gameObject.name == "orangeSpiral")
            {
                auraBubble.SetActive(true);
            }
            else if (other.gameObject.name == "pinkSpiral")
            {
                pickupHeart.SetActive(true);
            }
            else if (other.gameObject.name == "yellowSpiral")
            {
                pickupSmiley.SetActive(true);
            }
        }
        else if (other.gameObject.CompareTag("Angry") && Input.GetKeyDown(KeyCode.Z))
        {
            other.gameObject.SetActive(false);
            count -= 1;
            //winText.text = "-1";
            pressZ.SetActive(false);
            StartCoroutine(PerdreUnPoint());
            SetCountText();
            hpJoueur.value -= 10;
            if(hpJoueur.value <= 0)
            {
                DegatsRecus.instance.JoueurMort();
            }
            //if (hpJoueur.value <= 0 && hpZombie.value > 0)
            //    console.log(hpZombie);
            //{
            //    DegatsRecus.instance.JoueurMort();
            //}
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
                darkMagic.SetActive(true);
            }
            else if (other.gameObject.name == "purpleCane")
            {
                disruptiveForce.SetActive(true);
            }
            else if (other.gameObject.name == "yellowCane")
            {
                powEffect.SetActive(true);
            }
            else if (other.gameObject.name == "greenSpiral")
            {
                smokeEffect.SetActive(true);
            }
            else if (other.gameObject.name == "redSpiral")
            {
                rockEffect.SetActive(true);
            }
            else if (other.gameObject.name == "blueSpiral")
            {
                blueVirus.SetActive(true);
            }
        }

    }

    IEnumerator UnPoint()
    {
        unPoint.SetActive(true);
        yield return new WaitForSeconds(timer);
        unPoint.SetActive(false);
    }
    IEnumerator DeuxPoints()
    {
        twoPoints.SetActive(true);
        yield return new WaitForSeconds(timer);
        twoPoints.SetActive(false);
    }
    IEnumerator PerdreUnPoint()
    {
        malusUnPoint.SetActive(true);
        yield return new WaitForSeconds(timer);
        malusUnPoint.SetActive(false);
    }
}
