using System;
using System.Net.Http;
using Grpc.Net.Client;
using UnityEngine;
using BangBangLobby;

public class LobbyClient : MonoBehaviour
{
    private GrpcChannel _channel;
    private LobbyService.LobbyServiceClient _client;

    // Địa chỉ server gRPC
    private const string ServerAddress = "http://localhost:5000";

    private void Start()
    {
        // Tạo GrpcChannel với HTTP/2
        _channel = GrpcChannel.ForAddress(ServerAddress, new GrpcChannelOptions
        {
            MaxReceiveMessageSize = 10 * 1024 * 1024, // Tùy chỉnh giới hạn kích thước tin nhắn (nếu cần)
            HttpVersion = System.Net.HttpVersion.Version11  // Chỉ định sử dụng HTTP/2
        });

        _client = new LobbyService.LobbyServiceClient(_channel);
        JoinLobby("Player1");
    }

    // Tham gia Lobby
    private async void JoinLobby(string playerName)
    {
        var request = new JoinLobbyRequest { PlayerName = playerName };
        Debug.Log("Joining lobby...");
        var response = await _client.JoinLobbyAsync(request); // Gọi đến endpoint JoinLobby
        Debug.Log($"Response: {response}");
        Debug.Log(response.Message); // Hiển thị kết quả từ server
    }

    // Bắt đầu chọn Tank
    public async void StartTankSelection(string lobbyId)
    {
        var request = new StartTankSelectionRequest { LobbyId = lobbyId };
        var response = await _client.StartTankSelectionAsync(request); // Gọi đến endpoint StartTankSelection

        Debug.Log("Tank selection has started.");
    }

    // Chọn Tank
    public async void SelectTank(string playerId, string tankChoice)
    {
        var request = new TankSelectionRequest { PlayerId = playerId, TankChoice = tankChoice };
        var response = await _client.SelectTankAsync(request); // Gọi đến endpoint SelectTank

        if (response.IsTurn)
        {
            Debug.Log(response.Message); // Nếu đến lượt, hiển thị tin nhắn
        }
        else
        {
            Debug.Log(response.Message); // Nếu chưa đến lượt
        }

        // Hiển thị những người đã chọn tank
        foreach (var player in response.PlayersPicking)
        {
            Debug.Log($"Player {player} picked a tank.");
        }
    }

    private void OnDestroy()
    {
        // Đảm bảo đóng kết nối khi Unity kết thúc
        _channel?.ShutdownAsync().Wait();
    }
}