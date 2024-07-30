using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 vec = (player2.transform.position + player1.transform.position) / 2;

        transform.DOMove(new Vector3(vec.x, vec.y, -10),0.1f);
        //transform.position = new Vector3((vec.x / 2),vec.y/2,-10);
    }
}
