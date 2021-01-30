using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerDino : MonoBehaviour
{
    // Start is called before the first frame update
    private float move;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] CharacterAtack characterAtack;
    private CharacterLifeController lifeController;
    void Start()
    {
        lifeController = GetComponent<CharacterLifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            lifeController.Getdamage();

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            lifeController.RegenLife();

        }

        characterMovement.Jump(move);
        characterMovement.Dash(move);
        characterMovement.CheckLookAt();
        characterAtack.Sword();
        characterAtack.Shoot();    
        move = Input.GetAxis("Horizontal") * characterMovement.speed;
    }

    private void FixedUpdate()
    {
        characterMovement.move(move, false,false);

    }
}
