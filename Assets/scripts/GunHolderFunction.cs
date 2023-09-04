using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolderFunction : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite m1911;

    public Sprite m1Garand;
    public Sprite STG44;
    
    public Sprite BAR;
    public Sprite BREN;
    public Sprite MG42;
    
    public Sprite MP40;
    public Sprite M1Thompson;
    public Sprite STEN;
    
    public Sprite LUGERP08;
    public Sprite MAUSERC96;
    public Sprite WEBLEY;
    
    private BullletMovement damagebullet;
    private Weapon weapon;
    public int BulletDamage;
    public int tipo;

    private void Awake()
    {
        damagebullet = GameObject.Find("Player").GetComponent<Weapon>().BulletPrefab.GetComponent<BullletMovement>();
        weapon = GameObject.Find("Player").GetComponent<Weapon>();
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
    }



    public void ChangeSprite(int number, int damage)
    {
        /*if (number == 1)
        {
            spriteRenderer.sprite = m1911;
            BulletDamage = damage;
            if (damage > 35)
            {
                tipo = 1;
            }
            else
            {
                tipo = 2;
            }
            
            //damagebullet.setDamage(damage);
            weapon.canShoot = true;
            
        }
        else if (number == 2)
        {
            spriteRenderer.sprite = m1Garand;
            BulletDamage = damage;
            if (damage > 35)
            {
                tipo = 1;
            }
            else
            {
                tipo = 2;
            }
            //damagebullet.setDamage(damage);
            Debug.Log("el dano pasado es de " + BulletDamage);
            weapon.canShoot = true;

        }
        else if (number == 0)
        {
            spriteRenderer.sprite = newSprite2;
            tipo = 0;
            weapon.canShoot = false;
        }*/

        switch (number)
        {
            case 0:
                spriteRenderer.sprite = null;
                tipo = 0;
                weapon.canShoot = false;
                break;
            case 1:
                spriteRenderer.sprite = m1911;
                weapon.canShoot = true;
                break;
            case 2:
                spriteRenderer.sprite = m1Garand;
                weapon.canShoot = true;
                break;
            case 3:
                spriteRenderer.sprite = BAR;
                weapon.canShoot = true;
                break;
            case 4:
                spriteRenderer.sprite = BREN;
                weapon.canShoot = true;
                break;
            case 5:
                spriteRenderer.sprite = MG42;
                weapon.canShoot = true;
                break;
            case 6:
                spriteRenderer.sprite = STG44;
                weapon.canShoot = true;
                break;
            case 7:
                spriteRenderer.sprite = MP40;
                weapon.canShoot = true;
                break;
            case 8:
                spriteRenderer.sprite = M1Thompson;
                weapon.canShoot = true;
                break;
            case 9:
                spriteRenderer.sprite = STEN;
                weapon.canShoot = true;
                break;
            case 10:
                spriteRenderer.sprite = LUGERP08;
                weapon.canShoot = true;
                break;case 11:
                spriteRenderer.sprite = MAUSERC96;
                weapon.canShoot = true;
                break;case 12:
                spriteRenderer.sprite = WEBLEY;
                weapon.canShoot = true;
                break;

        }

        switch (damage)
        {
            case > 35:
                tipo = 1;
                BulletDamage = damage;
                break;
            case <= 35:
                tipo = 2;
                BulletDamage = damage;
                break;
        }

    }

}
