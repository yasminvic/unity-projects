using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //metodo que detecta toda colisão existente
    //o parametro é o objeto que colidiu 

    [SerializeField]
    private GameObject hitPrefab;

    [SerializeField]
    private GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shoot"))
        {
            //destrói o tiro
            Destroy(collision.gameObject);

            //instacia a animação do tiro no mesmo lugar do tiro
            Instantiate(hitPrefab, collision.transform.position, collision.transform.rotation);

            //destrói o enemy
            if(gameObject != null)
            {
                Destroy(gameObject);
            }

            //instacia a animação da explosão no mesmo lugar do enemy
            Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            
        }
    }
}
