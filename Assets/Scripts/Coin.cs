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
        Invoke("CoinLife", 5.0f);
    }

    private void CoinLife()
    {
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
            Invoke("DelayedDeath", 5.0f);
        }
    }

    private void DelayedDeath()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        coinMesh.SetActive(true);
        gameObject.SetActive(false);
    }
}
