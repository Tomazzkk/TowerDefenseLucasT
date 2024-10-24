using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BuildManager : MonoBehaviour //Classe para genrenciar as torres que tem no jogo
{
   public static BuildManager Instance;

    [Header("References")]
    //[SerializeField] private  GameObject[] towerPrefabs;
    [SerializeField] private Tower2[] towers; //Um array de objetos do tipo Tower2
    [SerializeField] int currentSelectedTower = 0; //índice para controlar qual torre está selecionada no momento para construir

    private int selectedTower = 0; //Variável que armazena o índice da torre que está atualmente selecionada



    private void Awake() //ele define a instância única(Instance) do BuildManager
    {
        Instance = this;
    }

    public Tower2 GetSelectedTower() //Retorna a torre atualmente selecionada pelo jogador, baseada no índice selectedTower
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) //Define a torre selecionada pelo jogador. O parâmetro "_selectedTower" é o índice da torre escolhida
    {
        selectedTower = _selectedTower; 
    }
}
