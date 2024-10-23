using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUi;

    private void OnGUI()
    {
        currencyUi.text = LevelManager.instance.currency.ToString();
    }

    public void SetSelected()
    {

    }
}
