using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Rigidbody Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        StartCoroutine(TimerToDisable());
    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private IEnumerator TimerToDisable()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
        
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Target>(out var target))
        {
            target.GetDamage(Random.Range(10, 15));
            gameObject.SetActive(false);
        }
    }
}
