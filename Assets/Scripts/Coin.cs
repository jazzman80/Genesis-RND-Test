using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [SerializeField] private GameEvent scoreEvent;
    [SerializeField] private ParticleSystem stars;
    [SerializeField] private GameObject coinMesh;
    
    public void CoinActivation()
    {
        StartCoroutine(CoinLife());
    }

    private IEnumerator CoinLife()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stars.Play();
            scoreEvent.Raise();
            coinMesh.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(DelayedDeath());
        }
    }

    private IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        coinMesh.SetActive(true);
        gameObject.SetActive(false);
    }
}
