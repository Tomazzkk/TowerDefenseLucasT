using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Classe que gerencia o jogo 
    public static LevelManager instance; // Variavel instance para poder acessar variaveis e metodos por outros scripts
    public Transform startPoint; // variavel para designar aonde o inimigo devera spawnar 
    public Transform[] path; // Variavel que mostra ao obj "Enemy" aonde ele devera mudar sua direcao quando chegar no "Point"

    public int currency; // Variavel para mostrar a quantidade de dinheiro que o usuario tem
    private void Awake() //Metedo awake para definir instance igual a ele mesmo enquanto o jogo carrega
    {
        instance = this;
    }

    private void Start() //Metodo start para atribuir valor a variavel currency, quando o jogo iniciar a variavel ira receber 150 como valor inicial
    {
        currency = 250;
    }

    public void IncreaseCurrency(int amount ) //Metodo com "amount" como parematro que é o dinheiro que ele ganha ao eliminar um inimigo, adicionando o valor de amount em currency
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount ) //Metodo para calcular quando o usuario comprar uma torre diminuir a variavel currency ou dizer ao usuario que ele nao tem dinheiro suficiente para comprar aquele item
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
