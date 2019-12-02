//using UnityEngine;
//using UnityEngine.Audio;
//using System;

//public class GestionSons : MonoBehaviour
//{

//    public Sons[] sons;
//    // Awake est appelé avant les fonctions Start
//    void Awake()
//    {
//        foreach(Sons unSonDeLaListe in sons)
//        {
//            unSonDeLaListe.audioSource = gameObject.AddComponent<AudioSource>();
//            unSonDeLaListe.audioSource.clip = unSonDeLaListe.clipAudio;

//            unSonDeLaListe.audioSource.volume = unSonDeLaListe.volume;
//            unSonDeLaListe.audioSource.pitch = unSonDeLaListe.tonalité;
//        }
//    }

//    public void JouerSon (string nomClipAudio)
//    {
//        Sons sonSelectionne = Array.Find(sons, sound => sound.nomMusique == nomClipAudio);
//        sonSelectionne.audioSource.Play();
//    }
//}
