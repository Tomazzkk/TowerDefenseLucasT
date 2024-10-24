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
    [SerializeField] int currentSelectedTower = 0; //�ndice para controlar qual torre est� selecionada no momento para construir

    private int selectedTower = 0; //Vari�vel que armazena o �ndice da torre que est� atualmente selecionada



    private void Awake() //ele define a inst�ncia �nica(Instance) do BuildManager
    {
        Instance = this;
    }

    public Tower2 GetSelectedTower() //Retorna a torre atualmente selecionada pelo jogador, baseada no �ndice selectedTower
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) //Define a torre selecionada pelo jogador. O par�metro "_selectedTower" � o �ndice da torre escolhida
    {
        selectedTower = _selectedTower; 
    }
}
