using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Src.Data
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {

        [Header("Player")]
        [SerializeField] private GameObject _player;
        [SerializeField] private Transform _spawnPosition;

        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        void InstatiatePlayer()
        {
            PhotonNetwork.Instantiate(_player.name, _spawnPosition.position, _spawnPosition.rotation, 0);
        }

        public override void OnConnectedToMaster()
        {
            Log("OnConnectedToMaster");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            Log("OnJoinedLobby");
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Log("OnJoinRoomFailed");
            PhotonNetwork.CreateRoom(null);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Log("OnCreateRoomFailed");
        }

        public override void OnJoinedRoom()
        {
            Log("OnJoinRoomFailed");
            InstatiatePlayer();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Log("OnDisconnected");
            Log("" + cause);
        }

        void Log(string msg)
        {
            Debug.Log(msg);
        }
    }
}