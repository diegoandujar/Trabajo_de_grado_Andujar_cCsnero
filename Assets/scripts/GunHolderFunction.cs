using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolderFunction : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite m1911;
    public Sprite m1Garand;
    public Sprite newSprite2;
    
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
        if (number == 1)
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
        }
            
        
    }

}
