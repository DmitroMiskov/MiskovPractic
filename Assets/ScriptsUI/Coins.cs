using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Coins : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    private CoinsCounter coinCounter;

    void Start()
    {
        coinCounter = GameObject.FindObjectOfType<CoinsCounter>();
    }

    private void PickUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this.gameObject, 0.3f);
        coinCounter.AddCoins(amount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PickUp();
    }
}
