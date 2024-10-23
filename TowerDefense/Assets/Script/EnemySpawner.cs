using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    //Classe que gerencia o Spawn dos inimigos

    [Header("References")]
    [SerializeField] public GameObject[] enemyPrefabs; // Array dos inimigos 

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8; //Numero de inimigos por onda
    [SerializeField] private float enemiesPerSecond = 0.5f; //Quantos inimigos por segundo é spawnado
    [SerializeField] private float timeBetWeenWaves = 5f; // tempo de pausa entre as ondas
    [SerializeField] private float difficultySaclingFactor = 0.75f; // o quanto de dificuldade que aumenta por onda
    

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent(); //Evento que acontece quando o inimigo é destruido

    private int currentWave = 1; //Onda atual de inimigos
    private float timeSinceLastSpawn; //Tempo que passou desde que o ultimo inimigo foi spawnado
    private int enemiesAlive; //Quantos inimigos vivos tem na cena
    private int enemiesLeftToSpawn; //Quantos inimigos restam para spawnar da aquela onda
    private bool isSpawning = false; // se esta spawnando inimigo ou nao
    int enemySelected; //inimigo selecionado para spawnar
    public static EnemySpawner Instance;//para facilitar o acesso a variaveis e metodos deste script
    


    



    private void Awake() //Metodo que é chamado quando o jogo esta carregando, instance é definido como ele mesmo e é adicionado um "EnemyDestroyed" na lista quando um inimigo é destruido
    {
           Instance = this;
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start() //Ao iniciar o jogo ele lanca uma onde de inimigos na cena
    {
        StartCoroutine(StartWave());
    }

    // O Update roda todo frame. Aqui, ele controla a lógica de spawn.
    private void Update()
    {
        if(!isSpawning) return;
       timeSinceLastSpawn  += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0 )
        {
            EndWave();
        }
    }
    
    void EnemyDestroyed() // Quando um inimigo é destruído, diminui o número de inimigos vivos.
    { 
        enemiesAlive--;
    }
    
    private IEnumerator StartWave() // Inicia uma nova onda depois de esperar um tempo.
    {
        yield return new WaitForSeconds(timeBetWeenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    
    void EndWave() // Quando uma onda termina, aumenta o número da onda, reseta o spawn, e começa outra.
    {
        currentWave++;
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
    }
    void SpawnEnemy()  // Método que spawn um inimigo. Escolhe um inimigo aleatório e o gera no ponto inicial.
    {
        enemySelected = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[enemySelected];
        Instantiate(prefabToSpawn, LevelManager.instance.startPoint.position, Quaternion.identity); 
    }
    int EnemiesPerWave()  // Calcula quantos inimigos terão na onda, com base na dificuldade que aumenta a cada onda.
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultySaclingFactor));
    }
}
