using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType { 
      Gun,
      DualSword
}

public class AwardItem : MonoBehaviour {

    private bool starMove = false;
    private Transform player;
    public AwardType type;
    public float speed = 8;
    public AudioClip PickClip;

    void Start()
    {
        Rigidbody rigidbody;
        rigidbody = GetComponent<Rigidbody> ();
        rigidbody.velocity = new Vector3(Random.Range(-5,5),0,Random.Range(-5,5));
        
       
    }
    void Update()
    {
        if (starMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position+Vector3.up, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position+Vector3.up) < 0.4f)
            {
                player.GetComponent<PlayerAward>().GetAward(type);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(PickClip, transform.position, 1f);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody;
        rigidbody = GetComponent<Rigidbody> ();
        if (collision.collider.tag == Tags.ground)
        {
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            SphereCollider col = this.GetComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = 2;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.player) {
            starMove = true;
            player = col.transform;
        }
    }
}
