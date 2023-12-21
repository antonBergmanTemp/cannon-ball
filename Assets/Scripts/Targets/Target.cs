using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int Bounty = 10;

    public int SecondsToRespawn = 5;

    private const int maxHP = 100;
    private int currentHP = 100;

    private Material mainMaterial;

    private Renderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        mainMaterial = meshRenderer.material;
    }

    public float RandomNumber() => Random.Range(0, 1);

    void OnEnable()
    {
        transform.DOMoveX(Random.Range(-10, 10), 2).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    public void GetDamage(int damage)
    {
        mainMaterial.DOColor(Color.white, 0.05f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBounce).OnComplete(()=>
        {
            Debug.Log("color changed");
        });

        transform.DOScale(damage % 10 + 1, 0.1f).SetLoops(2, LoopType.Yoyo);

        Debug.Log(damage + " was taken");

        currentHP -= damage;

        if (currentHP <= 0)
            Death();
    }

    private void Death()
    {
        GameHandler.GameInstance.uiModule.SetScore(20);


        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        StartCoroutine(RespawnTimer());
    }

    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(SecondsToRespawn);
        currentHP = maxHP;
        gameObject.SetActive(true);
    }
}
