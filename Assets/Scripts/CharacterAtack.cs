using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtack : MonoBehaviour
{
    private float timeCharge;
    [SerializeField]private float charged_shoot_time_minimum;
    public GameObject bullet;
    public GameObject chargedBullet;
    public float bullet_normal_velocity;
    public float bullet_charged_velocity;
    public CharacterMovement characterMove;
    public void Sword()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Sword");
        }
    }

    public void Shoot()
    {


        if (Input.GetKey(KeyCode.E))
        {
            timeCharge += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            ChargedShoot();
        }
    }

    private void ChargedShoot()
    {
        if (timeCharge >= charged_shoot_time_minimum)
        {
            Debug.Log("ChargedShoot");
            
            if (characterMove.right)
            {
                InsantiateBullet(bullet_charged_velocity, chargedBullet);
            }

            if (characterMove.left)
            {
                InsantiateBullet(-1 * bullet_charged_velocity, chargedBullet);
            }

            timeCharge = 0;
        }
        else
        {
            Debug.Log("Normal Shoot");
            
            if(characterMove.right)
            {
                InsantiateBullet(bullet_normal_velocity, bullet);
            }

            if (characterMove.left)
            {
                InsantiateBullet(-1 * bullet_normal_velocity, bullet);
            }
           
            timeCharge = 0;
        }
    }

    private void InsantiateBullet(float velocity, GameObject bullet)
    {
        GameObject bl = Instantiate(bullet, transform.position, Quaternion.identity);
        bl.GetComponent<Rigidbody2D>().AddForce(new Vector2 (velocity,0));

    }
}
