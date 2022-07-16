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

        /*
        players[0] = Instantiate(player, Vector3.down * 5, Quaternion.identity, transform);
        players[1] = Instantiate(player, Vector3.up * 5, Quaternion.identity, transform);
        if (numOfPlayers >= 3)
            players[2] = Instantiate(player, Vector3.right * 5, Quaternion.identity, transform);
        if (numOfPlayers == 4)
            players[3] = Instantiate(player, Vector3.left * 5, Quaternion.identity, transform);
        */

        for (int i = 0; i < numOfPlayers; i++)
        {
            Vector3 playerPos = new Vector3((i - 1) % 2 * -1, (i - 4) % 2 * -1, 0);

            players[i] = Instantiate(player, playerPos * 5, Quaternion.identity, transform);
            players[i].gameObject.name = "Player " + i;
        }
    }
}
