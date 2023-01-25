using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class BossScript : MonoBehaviour
{
    public GameObject PlayerObject;
    public AudioSource ReceiveDmg;
    public AudioSource Die;

    public int HitPoints = 15;

    private bool fight = false;
    private float attackTime = 0.0f;
    private PlayerInput input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fight && !PlayerObject.GetComponent<PlayerScript>().lose)
        {
            var gamepad = Gamepad.all.FirstOrDefault(g => input.devices.Any(d => d.deviceId == g.deviceId));
            gamepad.SetMotorSpeeds(0.123f, 0.234f);
            attackTime += Time.deltaTime;
            if (attackTime >= 5.0f)
            {
                PlayerObject.GetComponent<PlayerScript>().GetHit();
                attackTime = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == PlayerObject.GetComponent<BoxCollider2D>())
        {
            input = collision.GetComponent<PlayerInput>();
            fight = true;
            Debug.Log("BossFPlayer");
            
        }
    }

    public void LoseHP()
    {
        HitPoints--;
        ReceiveDmg.Play();
        Debug.Log("BossHit");
        if(HitPoints <= 0)
        {
            var gamepad = Gamepad.all.FirstOrDefault(g => input.devices.Any(d => d.deviceId == g.deviceId));
            gamepad.SetMotorSpeeds(0, 0);
            Die.Play();
            PlayerObject.GetComponent<PlayerScript>().win = true;
            Destroy(gameObject, 1);
        }
    }
}
