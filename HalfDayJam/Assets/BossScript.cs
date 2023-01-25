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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fight)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == PlayerObject.GetComponent<BoxCollider2D>())
        {
            fight = true;
        }
    }

    public void LoseHP()
    {
        HitPoints--;
        ReceiveDmg.Play();
        if(HitPoints <= 0)
        {
            Die.Play();
            Destroy(gameObject, 1);
        }
    }
}
