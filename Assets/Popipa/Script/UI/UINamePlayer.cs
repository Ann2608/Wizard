using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class UINamePlayer : MonoBehaviour
{
    public InputField NamePLayer;
    public Text name;
    public Button OkButton;
    private void Start()
    {
        OkButton.onClick.AddListener(OnOkClick);
    }

    private void OnOkClick()
    {
        string Name = NamePLayer.text;
        if (CheckName(Name))
        {
            name.text = "Nhập tên thành công";
            PlayerPrefs.SetString("PlayerName", Name); // Lưu tên vào PlayerPrefs-> dùng  để lưu tên nhân vật
            PlayerPrefs.Save(); // Lưu ngay lập tức
            SceneManager.LoadScene("Scene1");
                                        }
        else
        {
            name.text = "Tên không được để trống";
        }
    }

    bool CheckName(string Name)
    {
        return Regex.IsMatch(Name, "^[a-zA-Z0-9]");
    }
}
