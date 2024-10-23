using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;

    public int currency;
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 150;
    }

    public void IncreaseCurrency(int amount )
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount )
    {
        if(amount <= currency)
        {
            //Compra um Item
            currency -= amount;
            return true;
        }
        else {
            Debug.Log("Voce nao tem dinheiro para comprar este item");
            return false;
        }
    }
}
