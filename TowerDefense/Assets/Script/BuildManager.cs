using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
   public static BuildManager Instance;

    [Header("References")]
    [SerializeField] private  GameObject[] towerPrefabs;

    [SerializeField] int currentSelectedTower = 0;

    private int selectedTower = 0;



    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }
}
