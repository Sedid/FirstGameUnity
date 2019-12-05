using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sons
{

    public string nomDuSon;
    public AudioClip audioClip;

    //Ajoute un slider qui va de 0 à 1 pour modifier le volume
    [Range(0f, 1f)]
    public float volume = .75f;
    [Range(0f, 1f)]
    public float intensiteSon = .1f;

    [Range(.1f, 3f)]
    public float tonalite = 1f;
    [Range(0f, 1f)]
    public float intensiteTonalite = .1f;

    public bool boucle = false;

    //La valeur du champ est déjà manipulé dans la méthode Awake du script GestionSons,
    //Donc on utilise l'attribut HideInInspector pour que le champ n'apparaisse pas dans Unity
    [HideInInspector]
    public AudioSource source;

}
