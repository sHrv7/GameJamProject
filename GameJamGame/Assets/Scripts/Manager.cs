using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Sprite[] playerSprites = new Sprite[4];
    public GameObject[] players;

    public int currentPlayer = 0;

    private void Start()
    {
        SetUpGame(4);
        Camera.main.transform.Rotate(new Vector3(0, 0, 90));
    }

    public void EndTurn()
    {
        currentPlayer++;

        players[(currentPlayer - 1) % 4].GetComponent<Player>().isOnTurn = false;
        players[(currentPlayer - 1) % 4].GetComponent<Player>().hasRolled = false;
        players[(currentPlayer - 1) % 4].GetComponent<Player>().stun -= 20;
        players[currentPlayer % 4].GetComponent<Player>().isOnTurn = true;

        Camera.main.transform.Rotate(new Vector3(0, 0, 90));


    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //NextPlayer();
        }
    }
    public void SetUpGame(int numOfPlayers)
    {
        players = new GameObject[numOfPlayers];

        for (int i = 0; i < numOfPlayers; i++)
        {
            Vector3 playerPos = new Vector3((i - 1) % 2 * -1, (i - 2) % 2 * -1, -0.2f); //<---- Naci ova racunica

            players[i] = Instantiate(playerPrefab, playerPos * 10, Quaternion.Euler(0, 0, 90 + i * 90), transform);
            players[i].gameObject.name = "Player " + i;

            //playerov sprite
            players[i].gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[i];
        }

        players[0].GetComponent<Player>().isOnTurn = true;
    }
}
