using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoFunction : MonoBehaviour
{

    [SerializeField] public Text titulo;
    [SerializeField] public Text texto;
    [SerializeField] public Text texto1;
    [SerializeField] public Text texto2;
    [SerializeField] public Text texto3;
    [SerializeField] public Text texto4;
    [SerializeField] public Image imagen;

    public void printTexto(string Titulo, string Texto, string Texto1, string Texto2, string Texto3, string Texto4, Sprite arma)
    {
        titulo.text = Titulo;
        texto.text = Texto;
        texto1.text = Texto1;
        texto2.text = Texto2;
        texto3.text = Texto3;
        texto4.text = Texto4;
        imagen.sprite = arma;
        imagen.color = new Color(255, 255, 255, 112);
    }

}
