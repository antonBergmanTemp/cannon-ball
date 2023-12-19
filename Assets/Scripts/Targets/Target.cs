using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int Bounty = 10;

    private int currentHP = 100;

    public void GetDamage(int damage)
    {
        transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo);

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
