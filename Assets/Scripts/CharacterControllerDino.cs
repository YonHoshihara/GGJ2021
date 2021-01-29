using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerDino : MonoBehaviour
{
    // Start is called before the first frame update
    private float move;
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] CharacterAtack characterAtack;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        characterMovement.Jump(move);
        characterMovement.Dash(move);
        characterAtack.Sword();
        characterAtack.Shoot();
        move = Input.GetAxis("Horizontal") * characterMovement.speed;
    }

    private void FixedUpdate()
    {
        characterMovement.move(move, false,false);

    }
}
