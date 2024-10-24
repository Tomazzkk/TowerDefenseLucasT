using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Torre : MonoBehaviour, ITower //Classe Torre que herda MonoBehaviour e ITower
{
    [Header("Regerences")]
    [SerializeField] private Transform turretRotationPoint; // Ponto onde a torre rotaciona para mirar nos inimigos
    [SerializeField] protected LayerMask enemyMask; // layer usada para identificar os inimigos
    [SerializeField] private GameObject bulletPrefab; // Prefab da bala que a torre vai disparar
    [SerializeField] private Transform firingPoint;  // Ponto de onde a bala sai


    [Header("Attribute")]
    [SerializeField] protected float targetingRange = 5f; // Alcance da torre, dentro do qual ela pode mirar em inimigos
    [SerializeField] protected float rotationSpeed = 5f; // Velocidade de rota��o da torre para mirar no alvo
    [SerializeField] private float bps = 1f; //projeteis por segundo
   

    protected Transform target;  // O alvo atual da torre
    private float timeUntilFire; // Controle do tempo at� o pr�ximo disparo

    private void Update() //Chamado a cada frame. Verifica se a torre tem um alvo. Se n�o tem, chama o m�todo FindTarget() para procurar um.
    {
        if(  target == null )
        {
            FindTarget();
            return;
        }


        RotateTowardsTargert();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if( timeUntilFire >= 1f / bps) {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }
    private void Shoot() //M�todo respons�vel por instanciar o proj�til (bala) e definir o alvo da bala.
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bala bulletScript = bullet.GetComponent<Bala>();
        bulletScript.SetTarget(target);
    }
    public virtual void FindTarget() // M�todo virtual que ser� sobrescrito em classes filhas para definir como a torre encontra um alvo
    {
        
    }
   private  bool CheckTargetIsInRange() //Verifica se o alvo atual ainda est� dentro do alcance da torre
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

   void  RotateTowardsTargert() //Faz a torre rotacionar  em dire��o ao alvo usando o ponto de rota��o definido.
    {
        float angle = MathF.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


}
