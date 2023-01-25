using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    public string MaterialType;
    public GameObject PlayerObject;
    public AudioSource TrailSound;
    public AudioSource FindSound;
    public AudioSource MineResource;
    public AudioSource FinishedMining;
    public int HitPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(PlayerObject.transform.position, transform.position);
        TrailSound.volume = Mathf.Clamp(1.0f - (dist / 10.0f), 0.05f, 1.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == PlayerObject.GetComponent<BoxCollider2D>())
        {
            FindSound.Play();
            TrailSound.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == PlayerObject.GetComponent<BoxCollider2D>())
        {
            TrailSound.Play();
        }
    }

    public void MineRes()
    {
        HitPoints--;
        MineResource.Play();
        if(HitPoints <= 0)
        {
            DestroyResource();
        }
    }

    public void DestroyResource()
    {
        TrailSound.Stop();
        FindSound.Stop();
        if (MaterialType == "Rtx")
        {
            PlayerObject.GetComponent<PlayerScript>().RtxCount++;
        }
        else
        {
            PlayerObject.GetComponent<PlayerScript>().BeatCount++;
        }
        PlayerObject.GetComponent<PlayerScript>().mineRes = null;
        FinishedMining.Play();
        Destroy(gameObject, 2);
    }
}
