using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int RtxCount = 0;
    public int BeatCount = 0;

    private bool inRangeRtx = false;
    private bool inRangeBeat = false;

    private int HP = 5;

    public GameObject mineRes = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(mineRes != null)
            {
                mineRes.GetComponent<MineScript>().MineRes();
            }
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
}
