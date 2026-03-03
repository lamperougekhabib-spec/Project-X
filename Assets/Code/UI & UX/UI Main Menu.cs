using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    //Ini UI menu simple banget tapi bisa di scale kok, jadi kalau mau buat menu yang lebih bagus bisa di kembangkan lagi, tapi untuk sekarang ini cukup untuk prototype aja ya
    public void Play_Game()
    {
        SceneManager.LoadScene("Level 1");//ganti nama scene dengan nama scene yang akan di load pertama kali (namanya harus sama ya(huruf kapital dan yang lainya))
        Debug.Log("Play Game");
    }

    public void Continue()
    {
        int savedLevel = PlayerPrefs.GetInt("LastLevel", 1); // Mendapatkan indeks level terakhir yang disimpan, default ke 1 jika tidak ada
        SceneManager.LoadScene(savedLevel); // Memuat level terakhir yang disimpan
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();//ini sudah langsung keluar kalau muncul debug berarti udah keluar mungkin di play unity tidak terlihat tapi di build sudah keluar kok jadi tenang aja
    }
    public void Back_To_Menu()//ini untuk kemabali ke menu awwal biasanya di gunain ketika ui punya setting dan credit di menu awal (fungsi ini gunanaya untuk kembali ke menu awal)
    {
        SceneManager.LoadScene("SampleScene");//ganti nama scene dengan nama scene menu yang akan di load pertama kali (namanya harus sama ya(huruf kapital dan yang lainya))
        Debug.Log("Back To Menu");
    }
}
