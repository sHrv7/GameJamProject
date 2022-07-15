using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Player[] players;
    public void SetUpGame(int numOfPlayers)
    {
        players = new Player[numOfPlayers];
    }
}
