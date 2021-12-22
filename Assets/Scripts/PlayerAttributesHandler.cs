using Scriptable_Objects;
using UnityEngine;

public class PlayerAttributesHandler : MonoBehaviour{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CharactersEditor characterAttributes;
    [SerializeField] private SpriteRenderer characterSprite;

    private void Awake(){
        characterSprite = GetComponent<SpriteRenderer>();
        SetPlayerSprite();
        SetPlayerAttributes();
    }

    private void SetPlayerAttributes(){
        playerController.Damage = characterAttributes.damage;
        playerController.Rebound = characterAttributes.rebound;
        playerController.Health = characterAttributes.health;
        playerController.JumpForce = characterAttributes.jumpForce;
        playerController.AttackCoolDown = characterAttributes.attackCoolDown;
        playerController.Speed = characterAttributes.moveSpeed;
    }

    private void SetPlayerSprite(){
        characterSprite.sprite = characterAttributes.characterSprite;
    }

}
