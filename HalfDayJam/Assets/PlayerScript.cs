using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int RtxCount = 0;
    public int BeatCount = 0;
    public AudioSource HitSound;
    public AudioSource Wall;
    public GameObject boss;

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MineMaterial")
        {
            inRangeRtx = false;
            inRangeBeat = false;
        }
        mineRes = null;

        if(collision.tag == "Boss")
        {
            bossF = true;
            HP += BeatCount;
        }
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
        if(HP <= 0)
        {
            //Lose
        }
    }
}
