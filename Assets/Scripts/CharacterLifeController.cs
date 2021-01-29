using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLifeController : MonoBehaviour
{
    public GameObject[] lifes;
    private int totalLife;
    public int currentLife;
    void Start()
    {
        totalLife = lifes.Length;
        currentLife = totalLife;
    }
    public void Getdamage()
    {
        if (currentLife > 0)
        {
            currentLife--;
            lifes[currentLife].SetActive(false);
        }
    }
    public void RegenLife()
    {
        if (currentLife < totalLife)
        {
            currentLife++;
            lifes[currentLife - 1].SetActive(true);
        }
        
    }
}
