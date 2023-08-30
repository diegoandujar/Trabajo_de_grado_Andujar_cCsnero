using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{

    public GameObject menuPausaUI;
    private PlayerMovement PlayerMO;
    private Weapon PlayerWeapon;

    private bool statusWeapon;

    public static bool pausado = false;

    private void Awake()
    {
        PlayerMO = GameObject.Find("Player").GetComponent<PlayerMovement>();
        PlayerWeapon = GameObject.Find("Player").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (pausado)
            {
               
                resume();
            }
            else
            {
                statusWeapon = PlayerWeapon.canShoot;
                pausar();
            }
        }

    }

    public void resume()
    {
        if (statusWeapon)
        {
            PlayerWeapon.canShoot = true;
        }
        PlayerMO.enabled = true;
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void pausar()
    {
        if (statusWeapon)
        {
            PlayerWeapon.canShoot = false;
        }
        PlayerMO.enabled = false;
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void IrMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {
        Debug.Log("epale saliste");
        Application.Quit();
    }

}
