using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, HalfDayJam.IPlayerActions
{
    private Vector2 _moveOffset;
    private float _speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_moveOffset.x, _moveOffset.y, 0) * Time.deltaTime * _speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveOffset = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
}
