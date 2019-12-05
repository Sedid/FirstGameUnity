using UnityEngine.Audio;
using System;
using UnityEngine;

public class GestionSons : MonoBehaviour
{

    public Sons[] sons;

    // Awake est appelé avant les fonctions Start
    void Awake()
    {

        foreach (Sons unSon in sons)
        {
            unSon.source = gameObject.AddComponent<AudioSource>();
            unSon.source.clip = unSon.audioClip;
            unSon.source.loop = unSon.boucle;
        }

    }

    public void Play(string sound)
    {
        // "=>" : syntaxe pour les fonctions fléchées,
        // permet d'alléger le code
        // exemple : var a3 = a.map( s => s.length);
        // est équivalent à :
        // var a3 = a.map(function (s) { return s.length });
        Sons unSon = Array.Find(sons, item => item.nomDuSon == sound);
        if (unSon == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        unSon.source.volume = unSon.volume * (1f + UnityEngine.Random.Range(-unSon.intensiteSon / 2f, unSon.intensiteSon / 2f));
        unSon.source.pitch = unSon.tonalite * (1f + UnityEngine.Random.Range(-unSon.intensiteTonalite / 2f, unSon.intensiteTonalite / 2f));

        unSon.source.Play();
    }

    public void Pause(string sound)
    {
        Sons unSon = Array.Find(sons, item => item.nomDuSon == sound);
        unSon.source.Pause();
    }

}
