using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreNivelTres : Torre // Herda da classe Torre
{  
    public override void FindTarget() // M�todo que sobrescreve a l�gica de encontrar um alvo
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);// Faz um CircleCast, que � um circulo ao redor da torre. Ele procura inimigos dentro do alcance (targetingRange).

        if (hits.Length > 0)
        {
            int targetIndex = 0; // Escolhe o inimigo no �ndice 0

            if (hits.Length > targetIndex)
            {

                target = hits[targetIndex].transform;

            }

        }
    }
}
