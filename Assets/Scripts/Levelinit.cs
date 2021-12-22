using System;
using System.Collections;
using System.Collections.Generic;
using PlayMenu;
using UnityEngine;

public class Levelinit : MonoBehaviour{
    [SerializeField] private Transform[] playerSpawns;
    [SerializeField] private GameObject playerPrefab;

    private void Start(){
        var playerConfiguration = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfiguration.Length; i++){
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation,
                gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitPlayer(playerConfiguration[i]);
        }
    }
}