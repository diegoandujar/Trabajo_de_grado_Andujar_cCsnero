using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersInfo : MonoBehaviour
{
    [SerializeField] public string titulo;
    [SerializeField] public string texto1;
    [SerializeField] public string texto2;
    [SerializeField] public string texto3;
    [SerializeField] public string texto4;
    [SerializeField] public string texto5;
    [SerializeField] public Sprite imagen;
    [SerializeField] public AudioSource Narracion;

    private TextoCharacters textoPanel;

    private void Awake()
    {
        textoPanel = GameObject.Find("Texto").GetComponent<TextoCharacters>();
    }

    public void click()
    {
        textoPanel.printTextoCharac(titulo, texto1, texto2, texto3, imagen, Narracion);
    }

    public void clickUnidades()
    {
        textoPanel.printUnidades(titulo, texto1, imagen, Narracion);
    }

    public void clickBatalles()
    {
        textoPanel.printBatallas(titulo, texto1, texto2, texto3, Narracion);
    }

    public void printArmas()
    {
        textoPanel.printArmas(titulo, texto1, texto2, texto3, texto4, texto5, imagen, Narracion);
    }

}
