using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject PlayerObject;
    public AudioSource ReceiveDmg;
    public AudioSource Die;

    public int HitPoints = 15;

    private bool fight = false;
    private float attackTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fight && !PlayerObject.GetComponent<PlayerScript>().lose)
        {
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
            Die.Play();
            PlayerObject.GetComponent<PlayerScript>().win = true;
            Destroy(gameObject, 1);
        }
    }
}
