using UnityEngine;

namespace Scriptable_Objects{
    [CreateAssetMenu(fileName = "Data", menuName = "CharactersEditor/CharacterAttributes", order = 1)]
    public class CharactersEditor : ScriptableObject{
        [Header("Initial Character Picture")]
        public Sprite characterSprite;
        public float damage;
        public float health;
        [Header("Rebound is force to push other player when hit attacks")]
        public float rebound;
        public float jumpForce;
        [Header("AttackCoolDown is time between attacks")]
        public float attackCoolDown;
        public float moveSpeed;
    }
}