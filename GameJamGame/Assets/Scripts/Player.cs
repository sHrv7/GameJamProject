using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHealth = 150, currHealth;
    public bool isOnTurn = false;
    public int[] slots;
    public GameObject spell;
    private Transform playerHand;
    public Selector mouse;
    public int stun = 0;
    void Start()
    {
        mouse = transform.GetChild(1).GetComponent<Selector>();
        slots = new int[3];
        currHealth = startHealth;
        playerHand = transform.GetChild(0);
    }

    void Update()
    {
        if (isOnTurn && stun < 25)
        {

        }
    }
    void CombineDice()
    {
        GameObject spellObj = Instantiate(spell, playerHand, false);
        spellObj.GetComponent<Spell>().Create(slots[0], slots[1], slots[2]);
    }
    void CastSpell()
    {
        mouse.selectedCard.Cast();
    }
    public void EndTurn()
    {
        stun -= 20;
    }
}
