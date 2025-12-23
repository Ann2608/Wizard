using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    // UI
    public InputField usernameInput;
    public InputField passwordInput;
    public InputField emailInput;
    public InputField characterNameInput;
    public InputField mobileInput;
    public Text errorMessage;
    public Button registerButton;

    private string filePath = @"E:\3\account.txt"; // Lưu file

    void Start()
    {
        // Nút đăng ký
        registerButton.onClick.AddListener(OnRegisterClick);
    }

    // Đăng ký
    void OnRegisterClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string email = emailInput.text;
        string characterName = characterNameInput.text;
        string mobile = mobileInput.text;

        // Kiểm tra xem thông tin có đúng yêu cầu không
        if (IsValidUsername(username) && IsValidPassword(password) && IsValidEmail(email) &&
            IsValidCharacterName(characterName) && IsValidMobilePhone(mobile))
        {
            // Lưu tài khoản vào file
            SaveAccount(username, password, email, characterName, mobile);
            errorMessage.text = "Đăng ký thành công! Chuyển sang màn hình đăng nhập.";
            SceneManager.LoadScene("LoginScene");
        }
        else
        {
            errorMessage.text = "Thông tin không hợp lệ. Vui lòng kiểm tra lại!";
        }
    }

    // Username
    bool IsValidUsername(string username)
    {
        return Regex.IsMatch(username, "^[a-z0-9]{1,20}$");     //Chỉ bao gồm ký tự chữ cái viết thường và số
    }

    // Password
    bool IsValidPassword(string password)
    {
        return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@#$%]).{6,20}$");
        // Có ít nhất một chữ cái, Có ít nhất một chữ số, Có ít nhất một ký tự đặc biệt 
    }

    // Email
    bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@]+@[^@]+\.[^@]+$");
    }

    // Tên người dùng
    bool IsValidCharacterName(string name)
    {
        return name.Length <= 15;       //tên ngắn hơn 15 kí tự
    }

    // SDT
    bool IsValidMobilePhone(string phone)
    {
        return Regex.IsMatch(phone, @"^(0[3|5|7|8|9])+([0-9]{8})$");        // đầu 09 và có đủ 10 số
    }

    // Lưu tài khoản vào file
    void SaveAccount(string username, string password, string email, string characterName, string mobile)
    {
        string accountData = $"{username}\t{password}\t{email}\t{characterName}\t{mobile}";

        // Ghi vào file (ghi thêm vào cuối file nếu đã có dữ liệu)
        using (StreamWriter writer = new StreamWriter(filePath, true))   //FilePath: Định dạng đường dẫn ở trên  @"E:\3\account.txt"
            //true : ghi xuỗng dòng dưới, false : ghi đè lên file cũ
        {
            writer.WriteLine(accountData);          // mỗi tài khoản thêm vào một dòng mới
        }
    }
}
