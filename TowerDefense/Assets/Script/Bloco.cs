using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour //Classe que representa cada bloco que tem na cena
{
    [Header("Reference")]
    [SerializeField] private SpriteRenderer sr; //Um SpriteRenderer que controla a aparência visual do bloco (suas cores e sprite)
    [SerializeField] private Color HoverColor; //Uma cor que o bloco assumirá quando o mouse passar por cima dele


    private GameObject tower; //representa a torre construída em um bloco especifioco.
    private Color startColor; //Cor do bloco ao iniciar o jogo

    private void Start() //Define a cor do bloco ao iniciar o jogo
    {
        startColor = sr.color;
    }

    private void OnMouseEnter() //altera a cor do bloco ao passar o mouse encima
    {
        sr.color = Color.white;
    }

    private void OnMouseExit() //altera a cor do bloco quando o mouse sai de cima
    {
        sr.color = startColor;
    }

    private void OnMouseDown() //Metodo chamado quando o usuario clica no bloco, instanciando a torre selecionada
    {
        if (tower != null) return;

        
        
        Tower2 towerToBuild = BuildManager.Instance.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.instance.currency)
        {
            Debug.Log("Voce nao tem dinheiro para comprar esta torre");
            return;
        }

        LevelManager.instance.SpendCurrency(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        
    }
}
