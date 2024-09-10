using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField]
    private Joystick movementJoystick;

    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private Transform GunOffSet;

    //Start at 10:24 on How to make the player shoot.
    [SerializeField]
    private float TimeBetweenShots;

    [SerializeField]
    private float BulletSpeed;

    private float _lastFireTime;

    public float angle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceLastFire = Time.time - _lastFireTime;
        //if (movementJoystick.Direction.y != 0 || movementJoystick.Direction.x != 0)
       // {
            if(timeSinceLastFire >= TimeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
            }
       // }

        if (movementJoystick.Direction.x != 0)
        {
            angle = Mathf.Atan2(movementJoystick.Direction.y, movementJoystick.Direction.x) * Mathf.Rad2Deg;
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, GunOffSet.position, GunOffSet.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = BulletSpeed * transform.right;
        //uses transoform
    }

    private void OnFire()
    {

    }
}
