using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class VibrationController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private float duration;
    private Gamepad gamepad;

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartVibration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vibrate()
    {
        gamepad = GetGamePad();
        
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
