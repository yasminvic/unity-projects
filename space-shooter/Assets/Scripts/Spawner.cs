using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //Objeto a ser spawnado
    [Header("Prefab")]
    [SerializeField]
    private GameObject spawnPrefab;

    [Header("Delay")]
    [SerializeField]
    private float initialDelay = 1f;
    [SerializeField]
    private float spawnDelay = 1f;

    [Header("Range")]
    [SerializeField]
    private Range rangeX;
    [SerializeField]
    private Range rangeY;

    //é chamado só uma vez antes de qualquer Start, é um bom pra nao ter erro de referência
    private void Awake()
    {
        //invoca um metodo em um determinado tempo e repete ele de acordo com tempo definido
        InvokeRepeating(nameof(Spawn), initialDelay, spawnDelay);
    }

    void Spawn()
    {
        //gerando valores aletorios para x e y
        var randomX = Random.Range(rangeX.min, rangeX.max);
        var randomY = Random.Range(rangeY.min, rangeY.max);

        var position = new Vector3(
            transform.position.x + randomX,
            transform.position.y + randomY
        );
        //clona o objeto original e retorna o clone
        Instantiate(spawnPrefab, position, transform.rotation);
    }

    
}
