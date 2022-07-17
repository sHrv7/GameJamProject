using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private Text txt;
    private Player player;
    public bool health = true;
    void Start()
    {
        txt = GetComponent<Text>();
        player = transform.parent.parent.GetComponent<Player>();
    }

    void Update()
    {
        if (health)
        {
            txt.text = player.currHealth + "/" + player.startHealth;
        }
        else
        {
            txt.text = player.stun + "/20";
        }
    }
}
