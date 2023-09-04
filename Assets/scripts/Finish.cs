using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource FinishSound;

    private bool LevelCompleted = false;

    private ItemCollector item;

    private Animator anim;

    [SerializeField] bool ameica;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.Find("Player").GetComponent<ItemCollector>();
        FinishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !LevelCompleted && item.salvados==item.TotalSoldados)
        {
            FinishSound.Play();
            LevelCompleted = true;
            anim.SetTrigger("UP");
            //Invoke("LevelComplete", 2f); //Esto hace un deleay para hacer la transicion mas lenta, y se utilizo el invoke en vez de hacer con una animacion, ya que no hay
        }
        else if(collision.gameObject.name == "Player" && !LevelCompleted && item.bateries==9)
        {
            FinishSound.Play();
            LevelCompleted = true;
            anim.SetTrigger("UPB");
            //Invoke("LevelComplete", 2f); //Esto hace un deleay para hacer la transicion mas lenta, y se utilizo el invoke en vez de hacer con una animacion, ya que no hay
        }
    }



    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
