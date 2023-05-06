using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource FinishSound;

    private bool LevelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {

        FinishSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !LevelCompleted)
        {
            FinishSound.Play();
            LevelCompleted = true;
            Invoke("LevelComplete", 2f); //Esto hace un deleay para hacer la transicion mas lenta, y se utilizo el invoke en vez de hacer con una animacion, ya que no hay
        }
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
