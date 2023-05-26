using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delay = 5f;

    private void Awake()
    {
        //vai destruir o objeto em um tempo determinado
        Destroy(gameObject, delay);  
    }
}
