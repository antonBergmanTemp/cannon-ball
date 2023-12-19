using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootbase : MonoBehaviour
{
    public float force = 10;

    [SerializeField] private BallBase ballPrefab;

    [SerializeField] private Transform indicatorTransform;

    Vector3 direction = new Vector3();
    Vector3 currentPosition = new Vector3();

    private List<BallBase> ballsPool = new List<BallBase>();



    public void Shoot()
    {
        direction = indicatorTransform.forward + transform.forward;

        BallBase currentBall = GetFreeBall();

        if(currentBall == null)
        {
            currentBall = CreateNewBall();
        }

        currentBall.gameObject.SetActive(true);

        currentBall.Rigidbody.AddForce(direction * force, ForceMode.VelocityChange);
    }

    private BallBase CreateNewBall()
    {
        var ballGameObject = Instantiate(ballPrefab, transform.position, Quaternion.identity, null);

        ballsPool.Add(ballGameObject);

        return ballGameObject;
    }

    private BallBase GetFreeBall()
    {
        foreach(var item in ballsPool)
        {
            if (!item.isActiveAndEnabled)
            {
                item.transform.position = transform.position;
                item.Rigidbody.velocity = Vector3.zero;

                return item;
            }
        }

        return null;
    }
}
