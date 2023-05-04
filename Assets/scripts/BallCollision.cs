using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public AudioSource audio;
    public GameControlScript gcs;
    public RespawnGem rg;
    private bool isgameOver = false;
    void Update()
    {
        if(transform.position.x>6f || transform.position.x<-6f && !isgameOver)
        {
            isgameOver = true;
            gcs.gameOver();
        }
        else if(transform.position.z>10f || transform.position.z<-10f && !isgameOver)
        {
            isgameOver = true;
            gcs.gameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="collectable")
        {
            gcs.setScore();
            rg.respawn();
            audio.Play();
        }
    }
}
