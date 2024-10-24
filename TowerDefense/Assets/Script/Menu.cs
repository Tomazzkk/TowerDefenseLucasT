using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour //Classe responsavel pelo menu da loja
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUi; // Referência ao componente de texto que vai mostrar a moeda na interface

    private void OnGUI() // Esse método é chamado para atualizar a interface
    {
        currencyUi.text = LevelManager.instance.currency.ToString(); 
    }

   
}
