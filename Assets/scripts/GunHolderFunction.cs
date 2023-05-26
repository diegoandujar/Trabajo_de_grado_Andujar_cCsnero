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
            //damagebullet.setDamage(damage);
            weapon.canShoot = true;
            
        }
        else if (number == 2)
        {
            spriteRenderer.sprite = m1Garand;
            BulletDamage = damage;
            //damagebullet.setDamage(damage);
            Debug.Log("el dano pasado es de " + BulletDamage);
            weapon.canShoot = true;

        }
        else if (number == 0)
        {
            spriteRenderer.sprite = newSprite2;
            weapon.canShoot = false;
        }
            
        
    }

}
