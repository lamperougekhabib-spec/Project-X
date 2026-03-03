//kode ini di gunain kalo punya banyak audio ya gusy (contohnya banyak sfx dan bgm)
//ngatur audio emang susah si wkkwkwkwkwwk
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("BGM Clips")]
    //ini tergantung kalian punya bgm apa aja dan gunainya di mana bisa di tambahin/kurangin sesuai kebutuhan
    public AudioClip mainmenu;
    public AudioClip cutscene;
    public AudioClip gameplayBGM;

    [Header("SFX Clips")]
    public List<AudioClip> sfxClips;//ini bisa di tambahin sesuai kebutuhan

    private Dictionary<string, AudioClip> bgmDict;
    private Dictionary<string, AudioClip> sfxDict;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (bgmSource == null || sfxSource == null)
        {
            Debug.LogError("AudioSource belum di-assign!");
            return;
        }

        sfxSource.ignoreListenerPause = true;
        bgmSource.ignoreListenerPause = false;

        bgmSource.volume = Mathf.Clamp(PlayerPrefs.GetFloat("BGMVolume", 1f), 0f, 1f);
        sfxSource.volume = Mathf.Clamp(PlayerPrefs.GetFloat("SFXVolume", 1f), 0f, 1f);

        bgmDict = new Dictionary<string, AudioClip>
        {
            { "MainMenu", mainmenu },//ini nama nya bebas, tapi harus sama dengan yang di panggil di PlayBGM
            { "Cutscene", cutscene },//ini nama nya bebas, tapi harus sama dengan yang di panggil di PlayBGM
            { "Gameplay", gameplayBGM }//ini nama nya bebas, tapi harus sama dengan yang di panggil di PlayBGM
        };

        sfxDict = new Dictionary<string, AudioClip>();
        foreach (var clip in sfxClips)
        {
            if (clip != null && !sfxDict.ContainsKey(clip.name))
                sfxDict.Add(clip.name, clip);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            //ini juga sesuain sama nama bgm dan scene kalian okeh
            case "MainMenu":
                PlayBGM("MainMenu");
                break;
            case "Cutscene":
                PlayBGM("Cutscene");
                break;
            case "Level":
                PlayBGM("Gameplay");
                break;
            default:
                bgmSource.Stop();
                break;
        }
    }

    public void PlayBGM(string name, bool loop = true)
    {
        //ini fungsinya biar gak tabrakan sama sfx dan bgm lainya
        if (!bgmDict.TryGetValue(name, out var clip) || clip == null)
        {
            Debug.LogWarning("BGM not found: " + name);
            return;
        }

        if (bgmSource.clip == clip && bgmSource.isPlaying)
            return;

        bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void PlaySFX(string name)
    {
        if (!sfxDict.TryGetValue(name, out var clip))
        {
            Debug.LogWarning("SFX not found: " + name);
            return;
        }

        if (sfxSource.volume <= 0f)
            return;

        sfxSource.PlayOneShot(clip);
    }

    public void SetBGMVolume(float value)
    {
        //karena pakai si=lider di menu setting jadi harus pakai ini 
        value = Mathf.Clamp(value, 0f, 1f);
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        //karena pakai si=lider di menu setting jadi harus pakai ini
        value = Mathf.Clamp(value, 0f, 1f);
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
