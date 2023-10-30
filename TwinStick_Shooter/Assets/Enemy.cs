using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    public float speed;
    SpawnManager spawnManager;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.rotation = new Quaternion(0, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position =   Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(player.transform.position);
      //  transform.forward = player.position;
       
    }

    public void SetSpawner(SpawnManager _spawn)
    {
        spawnManager = _spawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            spawnManager.currentMonster.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            spawnManager.currentMonster.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
