using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Player player;
     float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        fireRate += Time.deltaTime;

        if (UnityEngine.InputSystem.Keyboard.current.spaceKey.isPressed && fireRate > .1f  || UnityEngine.InputSystem.Gamepad.current.aButton.wasPressedThisFrame && fireRate > .1f) 
       {
            FireBullet();
            fireRate = 0;
            ControllerRumble.Instance.RumbleImpulse(0.5f, 0.2f, 0.2f);
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
            bullet.transform.parent = null;
            bullet.SetActive(true);
        }

    }
}
