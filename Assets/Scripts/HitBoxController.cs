using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HitBoxController : MonoBehaviour{
    [FormerlySerializedAs("_enemyPlayer")] [SerializeField] private Transform enemyPlayer;

    public Transform GetEnemyPlayer(){
        return enemyPlayer;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            enemyPlayer = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            enemyPlayer = null;
        }
    }
}