using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Eixo X e Y")]
    [SerializeField]
    private Vector2 direction;

    [Header("Velocidade")]
    [SerializeField]
    private float moveSpeed;

    private void Update()
    {
        //para se movimentar linearmente
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
    }
}
