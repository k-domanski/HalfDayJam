using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, HalfDayJam.IPlayerActions
{
    private Vector2 _moveOffset;

    private Rigidbody2D _rigidbody;

    private float _speed = 10;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidbody.MovePosition(_moveOffset * Time.deltaTime * _speed);
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
        if(context.performed)
            GetComponent<VibrationController>().Vibrate();
    }
}
