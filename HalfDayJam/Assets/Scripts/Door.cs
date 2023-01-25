using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource onEnter;
    [SerializeField] private AudioSource Trail;

    [SerializeField] private GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("Enter");
            onEnter.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("Exit");
            if (other.GetComponent<PlayerController>().transform.position.y > transform.position.y)
            {
               collider.SetActive(true);
            }
        }
    }
}
