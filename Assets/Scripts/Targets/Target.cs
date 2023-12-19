using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int Bounty = 10;

    private int currentHP = 100;

    public void GetDamage(int damage)
    {
        Debug.Log(damage + " was taken");

        currentHP -= damage;

        if (currentHP <= 0)
            Death();
    }

    private void Death()
    {
        //todo add some logic to get xp
        
        gameObject.SetActive(false);
    }
}
