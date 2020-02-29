using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAbsorb : MonoBehaviour
{
    public GameObject player;
    public int starsToRevive;

    public static int revive;

    private static int score;

    void Update()
    {
        score = GameManager.score;  //  Update our score continuously.
    }

    void OnTriggerEnter(Collider other)
    {
        score = GameManager.score;

        revive += score;

        GameManager.gameManagerInstance.StarRevive(score);

        if (revive >= starsToRevive)
        {
            Destroy(this.gameObject);
        }
    }
}
