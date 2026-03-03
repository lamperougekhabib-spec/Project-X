using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public void Continue_Game()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex; // Mendapatkan indeks level saat ini

        PlayerPrefs.SetInt ("LastLevel", currentLevel + 1); // Menyimpan indeks level terakhir yang dimainkan
        PlayerPrefs.Save(); // Menyimpan perubahan ke PlayerPrefs
    }
}
