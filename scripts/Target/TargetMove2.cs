using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private CharacterController CC;
    private PropManager PM;


    public float MovementSpeed { get; set; }
    public float TwitchTime { get; set; }
    public bool MovingLeft { get; set; }

    private float BaseSpeed = 2.5f;

    void Awake()
    {        
        CC = GetComponent<CharacterController>();
        PM = PropManager.Instance;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        //if target hits left or right wall, change directions
        if (transform.position.x < -PM.RangeHalfWidth || transform.position.x > PM.RangeHalfWidth)
            FlipDirection();
        //move target left or right by current movement speed by frame time
        CC.Move((MovingLeft ? Vector3.left : Vector3.right) * MovementSpeed * Time.deltaTime);
    }

/*
    public void SetTarget()
    {
        MovementSpeed = MoveType();
        MovingLeft = RandomBool();

        float x = Random.Range(-PM.RangeHalfWidth, PM.RangeHalfWidth);
        float y = 1f; //Figure out this, height
        float z = PM.ActiveRow;


        transform.position = new Vector3(x,y,z);
        Debug.Log(transform.position +":" +z +":" + PM.ActiveRow +":" + transform.name);
    }
*/
    public void SetTarget()
    {
        MovementSpeed = MoveType();
        MovingLeft = RandomBool();

        float x = Random.Range(-PM.RangeHalfWidth, PM.RangeHalfWidth);
        float y = 1f; //Figure out this, height
        float z = PM.ActiveRow;

        transform.position = new Vector3(x, y, z);

        // Update the GameObject's position using the CharacterController.Move method.
        CC.Move((MovingLeft ? Vector3.left : Vector3.right) * MovementSpeed * Time.deltaTime);

        Debug.Log(transform.position + ":" + PM.ActiveRow + ":" + transform.name);
    }

    private float MoveType()
    {
        float Multiplier = 0;
        if (PM.CanWalk)
            Multiplier = (RandomBool() ? 0f : 1f);
        if (PM.CanRun)
            Multiplier = (RandomBool() ? 0f : 2f);
        if (PM.CanWalk && PM.CanRun)
            Multiplier = (int)Random.Range(0, 3);

        if (Multiplier >= 2)
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);


        return BaseSpeed * Multiplier;
    }
    private bool RandomBool()
    {
        return (Random.value >= 0.5);
    }
    public void FlipDirection()
    {
        MovingLeft = !MovingLeft;
    }
    public void TargetHit()
    {
        if (!PM.RandomSpawn)
        {
            FlipDirection();
            MovementSpeed = MoveType();
            return;
        }
        SetTarget();
    }
}
