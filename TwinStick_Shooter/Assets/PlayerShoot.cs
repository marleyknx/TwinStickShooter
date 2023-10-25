using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {



        if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame ) 
       {
            FireBullet();
       
       }


    }


    public void FireBullet()
    {
         GameObject bullet = PlayerPooling.instance.GetPooledBullet();
        if(bullet != null)
        {
            
            bullet.transform.parent = player.FirePoint;
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.rotation = transform.rotation;
         //   var bulletRb = PlayerPooling.instance.bullet.GetComponent<Rigidbody>();
          //  bulletRb.velocity = player.transform.forward * 800;
            bullet.SetActive(true);
        }

    }
}
