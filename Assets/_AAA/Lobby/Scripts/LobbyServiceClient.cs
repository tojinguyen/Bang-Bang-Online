using System;
using System.Collections;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using UnityEngine;
using LobbyService; 

public class LobbyServiceClient : MonoBehaviour
{
    private const string ServerAddress = "https://localhost:5001/bang-bang-lobby";  // Thay địa chỉ server của bạn
    private GrpcChannel channel;
    private Lobby.LobbyClient  client;

    void Start()
    {
        // Khởi tạo kênh gRPC
        channel = GrpcChannel.ForAddress(ServerAddress);
        client = new Lobby.LobbyClient(channel);

        // Gọi hàm kết nối vào lobby
        ConnectToLobby();
    }

    // Kết nối vào lobby
    async void ConnectToLobby()
    {
        try
        {
            var response = await client.JoinLobbyAsync(new JoinLobbyRequest
            {
                PlayerName = "Player_" + UnityEngine.Random.Range(1, 100).ToString()
            });

            Debug.Log("Đã kết nối vào lobby: " + response.LobbyId);

            // Sau khi vào lobby, cho phép người chơi chọn tank
            SelectTank();
        }
        catch (Exception e)
        {
            Debug.LogError("Kết nối thất bại: " + e.Message);
        }
    }

    // Chọn tank trong lobby
    async void SelectTank()
    {
        try
        {
            var response = await client.SelectTankAsync(new SelectTankRequest
            {
                TankType = "HeavyTank"  // Đây là loại tank được chọn
            });

            Debug.Log("Chọn tank thành công: " + response.TankType);
            
            // Sau khi chọn tank, có thể chuyển qua màn chơi
            StartMatchMaking();
        }
        catch (Exception e)
        {
            Debug.LogError("Chọn tank thất bại: " + e.Message);
        }
    }

    // Gọi hàm ghép trận ngẫu nhiên
    async void StartMatchMaking()
    {
        try
        {
            var response = await client.StartMatchMakingAsync(new MatchMakingRequest());

            Debug.Log("Ghép trận thành công! Trận ID: " + response.MatchId);

            // Sau khi ghép trận thành công, chuyển sang màn chơi
            StartGame(response.MatchId);
        }
        catch (Exception e)
        {
            Debug.LogError("Ghép trận thất bại: " + e.Message);
        }
    }

    // Bắt đầu trận đấu
    void StartGame(string matchId)
    {
        Debug.Log("Trận đấu bắt đầu với ID: " + matchId);
        // Ở đây có thể chuyển sang scene mới hoặc thực hiện hành động khi vào trận
    }

    void OnApplicationQuit()
    {
        // Đóng kết nối khi ứng dụng đóng
        channel.ShutdownAsync().Wait();
    }
}
