using System;
using UnityEngine;
[Serializable]
public class Tower2 //classe para organizar e poder definir os valores, nomes e prefab de cada torre 
{
    public string name;
    public int cost;
    public GameObject prefab;

    public Tower2(string _name, int _cost, GameObject _prefab) //MEtodo para referenciar o nome, custo, e prefab atraves do inspector da unity
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
