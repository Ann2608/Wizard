using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class UIOkMenu : MonoBehaviour
{
    // UI
    public Button Menu;

    void Start()
    {
        // Nút đăng nhập và đăng kí
        Menu.onClick.AddListener(OnMenuClick);
    }

    // Load màn hình đăng nhập
    void OnMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Kiểm tra thông tin đăng nhập
}
