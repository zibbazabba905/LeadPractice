using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    CharacterController Char;

    public bool IsMoving;
    public float Speed = 5;
    public bool Lefting;
    public bool Sprinting;
    public float Distance;

    void Awake()
    {
        Char = GetComponent<CharacterController>();
    }


    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (IsMoving)
        {
            if (transform.position.x < -TargetLayout.Instance.HalfRangeWidth || transform.position.x > TargetLayout.Instance.HalfRangeWidth)
                FlipDirection();
            
            Char.Move((Lefting ? Vector3.left : Vector3.right) * (Sprinting ? Speed : Speed * 0.5f) * Time.deltaTime);
        }
    }

    public void SetTarget(float Dist)
    {
        Distance = Dist;

        Lefting = RandomBool();
        SprintCheck();
        transform.position = new Vector3(Random.Range(-TargetLayout.Instance.HalfRangeWidth, TargetLayout.Instance.HalfRangeWidth), 1f, Distance * 10);
    }
    
    private bool RandomBool()
    {
        return (Random.value >= 0.5);
    }
    
    public void SprintCheck()
    {
        Sprinting = RandomBool();
        if (Sprinting)
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void FlipDirection()
    {
        Lefting = !Lefting;
    }

    public void TargetHit()
    {
        FlipDirection();
        SprintCheck();
    }
}
