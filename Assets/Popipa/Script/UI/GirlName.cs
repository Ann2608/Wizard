using UnityEngine;
using UnityEngine.UI;

public class PlayerNameDisplay : MonoBehaviour
{
    public Text playerNameText; // Kéo thả Text UI vào đây

    void Start()
    {
        // Lấy tên từ PlayerPrefs
        string playerName = PlayerPrefs.GetString("PlayerName", "Tên mặc định"); // "Tên mặc định" nếu không tìm thấy

        // Hiển thị tên
        if (playerNameText != null)
        {
            playerNameText.text = playerName;
        }
    }
}