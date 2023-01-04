using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static float horizontalInput, speed, xLimit;
    [SerializeField] private GameObject prefabFood;

    void Start()
    {
        speed = 25f;
        xLimit = 20f;
    }

    void FixedUpdate()
    {
        float xNewPos = transform.position.x + horizontalInput;
        if (xNewPos > -xLimit && xNewPos < xLimit)
            transform.Translate(new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime);

        /* Note: Less optimised code. Do not use. It's kept around because I've just discovered clamping and it's cool.
        ---------------------------------------------------------------------------------------------------------------
        float xPos, clamp;

        // Move the player
        transform.Translate(new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime);

        // If out of bounds, fix its position
        xPos = transform.position.x;
        clamp = (xPos < -xLimit) ? -xLimit : (xPos > xLimit) ? xLimit : xPos;
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
        */
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        // Go LEFT (left or up input) and go RIGHT (right or down input)
        Vector2 movementVector = ctx.ReadValue<Vector2>();
        horizontalInput = movementVector.x + -movementVector.y;
        if (horizontalInput < -1f) horizontalInput = -1f;
        else if (horizontalInput > 1f) horizontalInput = 1f;

        /*
            CODE EXPLANATION
            - The movementVector.y variable represents the UP/DOWN input, and since here "UP" is the same as "LEFT", it has to be a negative float, but originally "UP" is positive.
            For this reason, movementVector.y is inverted. Note that inverting a negative number makes it positive.
            - The X and Y inputs are added together because it's a simple way to find which input to use. The goal here is to find the one input that isn't 0, and if they're both in 
            use then we want the most "pronounced" one. This addition allows us to avoid if-statements, and lengthy ones at that.
            - The downside you could say is that if both inputs are used, then the sum can be more pronounced than it would be otherwise. For instance, -0.5f for X and -0.2f for 
            Y makes -0.7f, which is more intense of a movement than if we only took -0.5f into account. But if the player has an issue with it, not that they should, then they can 
            just press one key at a time for a given direction.
            - An actual issue with it, however, is that the sum can now be outside of the -1/+1 range, which is why there are checks to limit the sum if need be.
        */
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            Instantiate(prefabFood, transform.position + new Vector3(0f, 0f, 2f), prefabFood.transform.rotation);
    }
}
