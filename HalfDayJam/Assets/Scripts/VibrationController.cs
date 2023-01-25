using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private float duration;
    private Gamepad gamepad;

    private IEnumerator coroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInput>() != null)
        {
            other.GetComponent<PlayerScript>().Wall.Play();
            input = other.GetComponent<PlayerInput>();
            Vibrate();
        }
    }

    public void Vibrate()
    {
        gamepad = GetGamePad();
        coroutine = StartVibration();
        StartCoroutine(coroutine);
    }

    IEnumerator StartVibration()
    {
        float current = 0.0f;
        gamepad.SetMotorSpeeds(0.123f, 0.234f);
        while (current < duration)
        {
            current += Time.deltaTime;
            yield return null;
        }

        if (current >= duration)
        {
            gamepad.SetMotorSpeeds(0, 0);
            yield return null;
        }
    }
    private Gamepad GetGamePad()
    {
        return Gamepad.all.FirstOrDefault(g => input.devices.Any(d => d.deviceId == g.deviceId));
    }
}
