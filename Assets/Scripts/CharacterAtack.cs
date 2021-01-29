using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtack : MonoBehaviour
{
    private float timeCharge;
    [SerializeField]private float charged_shoot_time_minimum;
    // Start is called before the first frame update

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
            timeCharge = 0;
        }
        else
        {
            Debug.Log("Normal Shoot");
            timeCharge = 0;
        }
    }
}
