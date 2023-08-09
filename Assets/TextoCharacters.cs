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
    [SerializeField] public Image imagen;

    public void printTextoCharac(string Titulo, string Texto, string Texto1, string Texto2, Sprite Character)
    {
        titulo.text = Titulo;
        texto.text = Texto;
        texto2.text = Texto1;
        texto3.text = Texto2;
        imagen.sprite = Character;
        imagen.color = new Color(255, 255, 255, 112);
    }

    public void printUnidades(string Titulo, string Texto, Sprite Logo)
    {
        titulo.text = Titulo;
        texto.text = Texto;
        imagen.sprite = Logo;
        imagen.color = new Color(255, 255, 255, 112);
    }

    public void printBatallas(string Titulo, string Texto1, string Texto2, string Texto3)
    {
        titulo.text = Titulo;
        texto.text = Texto1;
        texto2.text = Texto2;
        texto3.text = Texto3;
    }

}
