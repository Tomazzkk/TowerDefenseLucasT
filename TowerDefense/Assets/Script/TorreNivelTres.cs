using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreNivelTres : Torre
{

    
    public override void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
}
