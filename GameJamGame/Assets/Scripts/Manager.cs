using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] players;
    private void Start()
    {
        SetUpGame(4);
    }
    public void SetUpGame(int numOfPlayers)
    {
        players = new GameObject[numOfPlayers];
        players[0] = Instantiate(player, Vector3.down * 5, Quaternion.identity, transform);
        players[1] = Instantiate(player, Vector3.up * 5, Quaternion.identity, transform);
        if (numOfPlayers >= 3)
            players[2] = Instantiate(player, Vector3.right * 5, Quaternion.identity, transform);
        if (numOfPlayers == 4)
            players[3] = Instantiate(player, Vector3.left * 5, Quaternion.identity, transform);
    }
}
