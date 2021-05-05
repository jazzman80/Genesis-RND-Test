using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int coinsCount;
    private List<GameObject> coinPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < coinsCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coinPool.Add(coin);
            //coin.transform.position = RandomPosition();
            //coin.GetComponent<Coin>().CoinActivation();
        }

        InvokeRepeating("InstantiateCoin", 1.0f, 0.1f);
    }

    private void InstantiateCoin()
    {
        for(int i = 0; i < coinsCount; i++)
        {
            if (!coinPool[i].activeSelf)
            {
                coinPool[i].SetActive(true);
                coinPool[i].transform.position = RandomPosition();
                coinPool[i].GetComponent<Coin>().CoinActivation();
                break;
            }
        }
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(-100.0f, 100.0f);
        float y = 10.0f;
        float z = Random.Range(-100.0f, 100.0f);
        return new Vector3(x, y, z);
    }

}
