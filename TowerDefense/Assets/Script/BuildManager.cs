using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
   public static BuildManager Instance;

    [Header("References")]
    //[SerializeField] private  GameObject[] towerPrefabs;
    [SerializeField] private Tower2[] towers;
    [SerializeField] int currentSelectedTower = 0;

    private int selectedTower = 0;



    private void Awake()
    {
        Instance = this;
    }

    public Tower2 GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower; 
    }
}
