using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use_Gun : MonoBehaviour
{

    private GunHolderFunction GunHolder;
    private slots slot;

    public int number;
    public int damage;
    


    private void Awake()
    {
        GunHolder = GameObject.Find("GunHolder").GetComponent<GunHolderFunction>();
        slot = GetComponentInParent<slots>();
    }

    public void UseGun()
    {
        GunHolder.ChangeSprite(number, damage);
        slot.usando = true;
    }
}
