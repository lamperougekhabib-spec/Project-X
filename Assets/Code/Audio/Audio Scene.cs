//Ini kalau kalian punya banyak scene yang butuh bgm yang beda - beda
//Karena di projectku sebelumnya ada custcene dan punya bgm yag beda jadi aku buat ini. Nah kode ini itu kalau kalian punya Menu Level/cutscene yang setiap evel dan custcene punya bgm yang beda beda bisa di tambahkan di sini.
//Sama jangan lupa setiap BGM dan scen namanya harus sama ya teman-teman
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioScene : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;

        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager tidak ditemukan!");
            yield break;
        }

        string scene = SceneManager.GetActiveScene().name;

        if (scene == "SampleScene")//ini sesuaiin sama nama scene kalian
            AudioManager.instance.PlayBGM("MainMenu");//ini juga sesuain sama nama BGM yang ada di Audio Manager kalian
        else if (scene == "Cutscene")//ini sesuaiin sama nama scene kalian
            AudioManager.instance.PlayBGM("Cutscene");//ini juga sesuain sama nama BGM yang ada di Audio Manager kalian
        //di sini kalian bisa tambahin bgm lagi jika punya pakai else if
    }
}