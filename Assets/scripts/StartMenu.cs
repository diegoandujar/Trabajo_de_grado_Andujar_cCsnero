using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update

    //[SerializeField] int numero;

    public void siguiente()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartGame()
    {

        SceneManager.LoadScene(8);
    }

    public void StarAgain()
    {

        SceneManager.LoadScene(0);
    }

    public void Armas()
    {
 
        SceneManager.LoadScene(1);
    }

    public void Character()
    {

        SceneManager.LoadScene(2);
    }

    public void backMenu()
    {

        SceneManager.LoadScene(0);
    }
    public void backCuriosidades()
    {

        SceneManager.LoadScene(3);
    }

    public void curiosidades()
    {

        SceneManager.LoadScene(3);
    }
    public void Zonas()
    {

        SceneManager.LoadScene(4);
    }
    public void Unidades()
    {

        SceneManager.LoadScene(5);
    }
    public void Batallas()
    {

        SceneManager.LoadScene(6);
    }
    public void Creditos()
    {

        SceneManager.LoadScene(7);
    }
    public void Instrucciones()
    {

        SceneManager.LoadScene(24);
    }
    public void Salir()
    {

        Debug.Log("epale saliste");
        Application.Quit();
    }

}
