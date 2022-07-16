using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHealth = 150, currHealth;
    public bool isOnTurn = false;
    public GameObject[] slots;
    public int[] slotValues;
    public GameObject spell;
    private Transform playerHand;
    public Selector mouse;
    public int stun = 0;
    void Start()
    {
        mouse = transform.GetChild(1).GetComponent<Selector>();
        slots = new GameObject[3];
        slotValues = new int[3];
        slots[0] = transform.GetChild(2).GetChild(0).gameObject;
        slots[1] = transform.GetChild(2).GetChild(1).gameObject;
        slots[2] = transform.GetChild(2).GetChild(2).gameObject;
        currHealth = startHealth;
        playerHand = transform.GetChild(0);
    }

    void Update()
    {
        slotValues[0] = slots[0].GetComponent<Slot>().num;
        slotValues[1] = slots[1].GetComponent<Slot>().num;
        slotValues[2] = slots[2].GetComponent<Slot>().num;
        if (isOnTurn && stun < 25)
        {
            mouse.gameObject.SetActive(true);
        }
        else
        {
            mouse.gameObject.SetActive(false);
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
