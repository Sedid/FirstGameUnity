using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestionDialogues : MonoBehaviour
{
    // Queue = liste avec des contraintes
    Queue<string> phrases;

    public Animator animator;

    public Text nomJoueur;
    public Text texteDialogue;

    // Start is called before the first frame update
    void Start()
    {
        phrases = new Queue<string>();
    }

    public void CommencerDialogue(Dialogues dialogue)
    {

        animator.SetBool("dialogue_ouvert", true);

        //Debug.Log("Commencer la conversation avec " + dialogue.nameNpc);

        nomJoueur.text = dialogue.nameNpc;

        // nettoie les phrases des précédentes conversations
        phrases.Clear();

        // boucle dans tous les caractères des phrases
        foreach (string phrase in dialogue.phrases)
        {
            // ajoute les phrases à la liste
            phrases.Enqueue(phrase);
        }

        AfficherPhraseSuivante();
    }

    public void AfficherPhraseSuivante()
    {
        // Vérifie s'il y a encore des phrases contenues dans la liste
        if (phrases.Count == 0)
        {
            DialogueTermine();
            return;
        }

       // Retire de la liste les phrases restantes
       string phrase = phrases.Dequeue();

        // Arrête toutes les coroutines avant que la prochaine coroutine soit appelée
        StopAllCoroutines();
        StartCoroutine(LecturePhrases(phrase));

    }

    // fait progressivement apparaître la phrase dans la boite de dialogue
    IEnumerator LecturePhrases (string phrase)
    {
        texteDialogue.text = "";
        foreach (char lettre in phrase.ToCharArray())
        {
            texteDialogue.text += lettre;
            yield return null;
        }
    }

    public void DialogueTermine()
    {
        //Debug.Log("Fin de la conversation");
        animator.SetBool("dialogue_ouvert", false);
        if (GameObject.Find("Dialogue_png_1") != null)
        {
            GameObject.Find("Dialogue_png_1").SetActive(false);
        }
        if (GameObject.Find("Dialogue_png_2") != null)
        {
            GameObject.Find("Dialogue_png_2").SetActive(false);
        }
    }
}
