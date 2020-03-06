using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StarAbsorb : MonoBehaviour
{
    public GameObject player;
    public int starsToRevive;

    public static int starsNeededToRevive;

    public static int revive;

    private static int score;

    void Start()
    {
        starsNeededToRevive = starsToRevive;
    }
    void Update()
    {
        score = GameManager.score;  //  Update our score continuously.
    }

    void OnTriggerEnter(Collider other)
    {
        revive += score;

        GameManager.gameManagerInstance.StarRevive(score);

        if (revive >= starsToRevive)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
