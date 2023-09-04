using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoCharacters : MonoBehaviour
{
    [SerializeField] public Text titulo;
    [SerializeField] public Text texto;
    [SerializeField] public Text texto2;
    [SerializeField] public Text texto3;
    [SerializeField] public Text texto4;
    [SerializeField] public Text texto5;
    [SerializeField] public Image imagen;
    [SerializeField] public AudioSource currentAudio = null;

    public void printTextoCharac(string Titulo, string Texto, string Texto1, string Texto2, Sprite Character, AudioSource audio)
    {
        if (currentAudio != null)
        {
            currentAudio.Stop();
        }
        currentAudio = audio;
        currentAudio.Play();
        titulo.text = Titulo;
        texto.text = Texto;
        texto2.text = Texto1;
        texto3.text = Texto2;
        imagen.sprite = Character;
        imagen.color = new Color(255, 255, 255, 112);
    }

    public void printUnidades(string Titulo, string Texto, Sprite Logo, AudioSource audio)
    {
        if (currentAudio != null)
        {
            currentAudio.Stop();
        }
        currentAudio = audio;
        currentAudio.Play();
        titulo.text = Titulo;
        texto.text = Texto;
        imagen.sprite = Logo;
        imagen.color = new Color(255, 255, 255, 112);
    }

    public void printBatallas(string Titulo, string Texto1, string Texto2, string Texto3, AudioSource audio)
    {
        if (currentAudio != null)
        {
            currentAudio.Stop();
        }
        currentAudio = audio;
        currentAudio.Play();
        titulo.text = Titulo;
        texto.text = Texto1;
        texto2.text = Texto2;
        texto3.text = Texto3;
    }

    public void printArmas(string Titulo, string Texto1, string Texto2, string Texto3, string Texto4, string Texto5, Sprite arma, AudioSource audio)
    {
        if (currentAudio != null)
        {
            currentAudio.Stop();
        }
        currentAudio = audio;
        currentAudio.Play();
        titulo.text = Titulo;
        texto.text = Texto1;
        texto2.text = Texto2;
        texto3.text = Texto3;
        texto4.text = Texto4;
        texto5.text = Texto5;
        imagen.sprite = arma;
        imagen.color = new Color(255, 255, 255, 112);
        //audio.Play();
    }

}
