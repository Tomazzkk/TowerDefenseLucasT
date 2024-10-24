using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour //Classe responsavel pela movimentacao do inimigo
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; //Variavel para referenciar o Rigidbody2d do inimigo
    [Header("Attributes")]
    [SerializeField] private float movespeed = 2f; //variavel speed do inimigo

    private Transform target; //m Transform que representa o ponto atual do caminho que o inimigo deve alcan�ar
    private int pathIndex = 0; // Um �ndice inteiro que rastreia qual ponto do caminho o inimigo est� seguindo.

    private void Start() //M�todo chamado na inicializa��o do objeto. Aqui, o target � definido como o primeiro ponto do caminho
    {
        target = LevelManager.instance.path[pathIndex];
    }
    private void Update() //erifica se o inimigo est� pr�ximo o suficiente do ponto de destino, Se a dist�ncia for menor ou igual a 0.1 unidades, significa que o inimigo chegou ao ponto 
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex >= LevelManager.instance.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex];
            }
        }
    }
    private void FixedUpdate() //Calcula a dire��o do inimigo em rela��o ao target e ajusta a velocidade do Rigidbody2D (rb) para mover o inimigo nessa dire��o com a velocidade definida em movespeed.
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * movespeed;
    }
}
