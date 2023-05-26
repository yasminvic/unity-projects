using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //coloca um titulo no Unity
    [Header("Move")]
    //Faz com que variavel apare�a no Unity
    [SerializeField]
    private float moveSpeed = 1f;

    [Header("Bounds")]
    [SerializeField]
    private BoxCollider2D playerBounds;


    [Header("Shoot")]

    [SerializeField]
    private GameObject shootPrefab; //objeto que vai ser instaciado quando atirar

    [SerializeField]
    private Transform shootPivot; //local de onde vai sair o tiro

    [SerializeField]
    private GameObject flashGameObject; //flash que aparece quando atira

    [SerializeField]
    private float delayFlash = 0.1f;


    void Update()
    {
        //Controlar movimentos
        Move();

        //Impedir que saia da janela
        ApplyBounds();

        //Atirar
        Shoot();
    }

    void Move()
    {
        //movimenta��o
        var h = Input.GetAxis("Horizontal"); //pegar eixo x
        var v = Input.GetAxis("Vertical"); //pegar eixo y

        var move = new Vector3(
            h * moveSpeed * Time.deltaTime,
            v * moveSpeed * Time.deltaTime

        );

        transform.Translate(move);
    }

    void ApplyBounds()
    {
        var minX = -playerBounds.bounds.extents.x + playerBounds.offset.x;
        var maxX = playerBounds.bounds.extents.x + playerBounds.offset.x;

        var minY = -playerBounds.bounds.extents.y + playerBounds.offset.y;
        var maxY = playerBounds.bounds.extents.y + playerBounds.offset.y;

        //define a posi��o do player
        transform.position = new Vector3(
            //vai garantir que o valor de x e y tenha um min e max
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );
    }

    void Shoot()
    {
        //se n�o for cliacado a tecla espa�o, ent retorna vazio
        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }

        //se for, ent instacia o objeto do tiro no shootPivot
        Instantiate(shootPrefab, shootPivot.position, shootPivot.rotation);

        //Faz com que o objeto do flash se torne visivel 
        flashGameObject.SetActive(true);
        //Invoca um metodo que vai tornar o flash invisivel e tem um delay pra isso acontecer
        Invoke(nameof(HideFlash), delayFlash);

    }

    void HideFlash()
    {
            flashGameObject.SetActive(false);
        
    }
}
