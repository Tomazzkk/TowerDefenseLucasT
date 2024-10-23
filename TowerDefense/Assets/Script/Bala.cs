using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Classe que gerencia a açao da bala
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; // Variavel para controlar a fisica 

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f; //Variavel para controlar a velocidade em que a bala chega no inimigo
    [SerializeField] private int bulletDamage = 1; //Variavel para controlar o dano que a bala da em cada inimigo


    private Transform target; //Variavel para o alvo da bala

    public void SetTarget(Transform _target) // Método com parametro que define o alvo
    {
        target = _target;
    }



    private void FixedUpdate() //Metodo que é usado em um intevalo de tempo fixo, verifica se a bala tem um alvo e se tiver ele calcula a direcao do alvo para enviar a bala
    {
        if(!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) //Método para verificar se dois obj com Collider se colidiram, no caso se colidir o inimigo vai tomar dano e destruir a bala
    {
        collision.gameObject.GetComponent<Vida>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
