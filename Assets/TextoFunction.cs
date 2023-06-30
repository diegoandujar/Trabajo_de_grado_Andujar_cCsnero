using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoFunction : MonoBehaviour
{

    [SerializeField] public Text titulo;
    [SerializeField] public Text texto;
    [SerializeField] public Image imagen;

    public void printTexto(string Titulo, string Texto, Sprite arma)
    {
        titulo.text = Titulo;
        texto.text = Texto;
        imagen.sprite = arma;
        imagen.color = new Color(255, 255, 255, 112);
    }

}
