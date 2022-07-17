using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    int currentPlayer = 0;
    int numOfPlayers = 3;

    public GameObject playerPrefab;
    public Sprite[] playerSprites = new Sprite[4];
    public GameObject[] players;

    private void Start()
    {
        SetUpGame(numOfPlayers);
        Camera.main.transform.Rotate(new Vector3(0, 0, 90));
    }

    public void EndTurn()
    {
        currentPlayer++;

        players[(currentPlayer - 1) % numOfPlayers].GetComponent<Player>().isOnTurn = false;
        players[(currentPlayer - 1) % numOfPlayers].GetComponent<Player>().hasRolled = false;
        players[(currentPlayer - 1) % numOfPlayers].GetComponent<Player>().stun -= 20;
        players[currentPlayer % numOfPlayers].GetComponent<Player>().isOnTurn = true;

        if(numOfPlayers == 3)
        {
            if (currentPlayer % numOfPlayers == 0)
                Camera.main.transform.Rotate(new Vector3(0, 0, 180));
            else
                Camera.main.transform.Rotate(new Vector3(0, 0, 90));
        }
        else
            Camera.main.transform.Rotate(new Vector3(0, 0, 360 / numOfPlayers));
    }
    public void SetUpGame(int numOfPlayers)
    {
        players = new GameObject[numOfPlayers];

        Vector3 playerPos = new Vector3(0, 0, 0);
        Quaternion playerRotation = new Quaternion(0, 0, 0, 0);

        for (int i = 0; i < numOfPlayers; i++)
        {
            if (numOfPlayers == 2)
            {
                playerPos = new Vector3(i * - 2 + 1, 0, -0.2f);
                playerRotation = Quaternion.Euler(0, 0, 90 + i * 180);   
            }

            else if (numOfPlayers >= 3)
            {
                playerPos = new Vector3((i - 1) % 2 * -1, (i - 2) % 2 * -1, -0.2f); //<---- Naci ova
                playerRotation = Quaternion.Euler(0, 0, 90 + i * 90);
            }

            players[i] = Instantiate(playerPrefab, playerPos * 10, playerRotation, transform);

            players[i].gameObject.name = "Player " + i;

            //playerov sprite
            players[i].gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[i];
        }

        players[0].GetComponent<Player>().isOnTurn = true;
    }
}
