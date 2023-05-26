using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //metodo que detecta toda colis�o existente
    //o parametro � o objeto que colidiu 

    [SerializeField]
    private GameObject hitPrefab;

    [SerializeField]
    private GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            //destr�i o tiro
            Destroy(collision.gameObject);

            //instacia a anima��o do tiro no mesmo lugar do tiro
            Instantiate(hitPrefab, collision.transform.position, collision.transform.rotation);

            //destr�i o enemy
            if(gameObject != null)
            {
                Destroy(gameObject);
            }

            //instacia a anima��o da explos�o no mesmo lugar do enemy
            Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            
        }
    }
}
