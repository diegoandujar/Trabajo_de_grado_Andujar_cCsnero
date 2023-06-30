using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaInformacion : MonoBehaviour
{
    [SerializeField] public string titulo;
    [SerializeField] public string texto;
    [SerializeField] public Sprite imagen;

    private TextoFunction textoPanel;

    private void Awake()
    {
        textoPanel = GameObject.Find("Texto").GetComponent<TextoFunction>();
    }

    public void click()
    {
        textoPanel.printTexto(titulo, texto, imagen);
    }

}
