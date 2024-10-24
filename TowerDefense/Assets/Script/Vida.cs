using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour // Classe responsavel para definir quanto de vida o inimigo vai ter.
{
    [Header("Attribues")]
    [SerializeField] private int hitPoints = 2; //Quantos hits o inimigo vai tomar para destruir
    [SerializeField] private int currencyWorth = 50; //Dinheiro que ira ganhar ao destruir o inimigo
    private bool isDestroyed = false; //m booleano que indica se o inimigo já foi destruído.

    public void TakeDamage(int dmg) //Este método é chamado para aplicar dano ao inimigo, onde o valor de dmg é subtraido de hitPoints
    {
        hitPoints -= dmg;

        if(hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.instance.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
