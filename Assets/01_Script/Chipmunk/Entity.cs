using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _moveSpace = 1f;
    private void Update()
    {
    }
    public virtual void Move(Vector3 direction)
    {
        transform.position += direction;
    }
}
