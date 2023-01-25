using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int RtxCount = 0;
    public int BeatCount = 0;
    public AudioSource HitSound;
    public AudioSource Wall;
    public AudioSource YaySound;
    public AudioSource LoseSound;
    public GameObject boss;
    public bool win = false;
    public bool lose = false;

    private bool inRangeRtx = false;
    private bool inRangeBeat = false;

    private int HP = 10;
    private bool bossF = false;

    public GameObject mineRes = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            YaySound.Play();
            win = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MineMaterial")
        {
            if(collision.GetComponent<MineScript>().MaterialType == "Rtx")
            {
                inRangeRtx = true;
            }
            else
            {
                inRangeBeat = true;
            }
            mineRes = collision.gameObject;
        }

        if (collision.tag == "Boss")
        {
            bossF = true;
            Debug.Log("PlayerFBoss");
            HP += BeatCount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MineMaterial")
        {
            inRangeRtx = false;
            inRangeBeat = false;
        }
        mineRes = null;
    }

    public void ClickMine()
    {
        if (mineRes != null)
        {
            mineRes.GetComponent<MineScript>().MineRes();
        }

        if (bossF)
        {
            boss.GetComponent<BossScript>().LoseHP();
        }
    }

    public void GetHit()
    {
        HP--;
        HitSound.Play();

        Debug.Log("PlayerHit");
        if (HP <= 0)
        {
            lose = true;
            LoseSound.Play();
            Destroy(gameObject, 15);
        }
    }

    public void DealDamage(int amount)
    {
        HP -= amount;
    }
}
