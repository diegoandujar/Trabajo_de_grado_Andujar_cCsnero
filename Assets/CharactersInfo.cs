using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersInfo : MonoBehaviour
{
    [SerializeField] public string titulo;
    [SerializeField] public string texto1;
    [SerializeField] public string texto2;
    [SerializeField] public string texto3;
    [SerializeField] public Sprite imagen;

    private TextoCharacters textoPanel;

    private void Awake()
    {
        textoPanel = GameObject.Find("Texto").GetComponent<TextoCharacters>();
    }

    public void click()
    {
        textoPanel.printTextoCharac(titulo, texto1, texto2, texto3, imagen);
    }

    public void clickUnidades()
    {
        textoPanel.printUnidades(titulo, texto1, imagen);
    }

    public void clickBatalles()
    {
        textoPanel.printBatallas(titulo, texto1, texto2, texto3);
    }

}
