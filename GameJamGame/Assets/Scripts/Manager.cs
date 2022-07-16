using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] players;

    int currentPlayer = 0;

    private void Start()
    {
        SetUpGame(4);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentPlayer++;

            players[currentPlayer % 4].GetComponent<Player>().isOnTurn = true;
            players[(currentPlayer - 1) % 4].GetComponent<Player>().isOnTurn = false;
        }
    }

    public void SetUpGame(int numOfPlayers)
    {
        players = new GameObject[numOfPlayers];

        for (int i = 0; i < numOfPlayers; i++)
        {
            Vector3 playerPos = new Vector3((i - 1) % 2 * -1, (i - 2) % 2 * -1, -0.2f);

            players[i] = Instantiate(player, playerPos * 5, Quaternion.Euler(0, 0, 90 + i * 90), transform);
            players[i].gameObject.name = "Player " + i;
        }
    }
}
