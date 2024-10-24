using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreNivelDois : Torre // Herda da classe Torre
{
    public override void FindTarget() // M�todo que sobrescreve a l�gica de encontrar um alvo
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask); // Faz um CircleCast, que � como um "radar" circular ao redor da torre. Ele procura inimigos dentro do alcance (targetingRange).

        if (hits.Length > 0)
        {

            int targetIndex = 2; // Escolhe o inimigo no �ndice 2

            if (hits.Length > targetIndex)
            {

                target = hits[targetIndex].transform;

            }   
        }

    }
}
