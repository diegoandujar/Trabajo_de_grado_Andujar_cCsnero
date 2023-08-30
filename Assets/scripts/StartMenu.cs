using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StarAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

    public void Armas()
    {
        SceneManager.LoadScene(9);
    }

    public void Character()
    {
        SceneManager.LoadScene(8);
    }

    public void backMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void backCuriosidades()
    {
        SceneManager.LoadScene(10);
    }

    public void curiosidades()
    {
        SceneManager.LoadScene(10);
    }
    public void Zonas()
    {
        SceneManager.LoadScene(11);
    }
    public void Unidades()
    {
        SceneManager.LoadScene(12);
    }
    public void Batallas()
    {
        SceneManager.LoadScene(13);
    }

}
