using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Graphicsetting : MonoBehaviour
{
    public TMP_Dropdown graphicdropdown;
    int pilihkualitas;

    void Start()
    {
        graphicdropdown.ClearOptions();
        graphicdropdown.AddOptions(new List<string>(QualitySettings.names));

        pilihkualitas = PlayerPrefs.GetInt(
        "QualityLevel",
        QualitySettings.GetQualityLevel()
    );

        graphicdropdown.value = pilihkualitas;
        graphicdropdown.RefreshShownValue();
        applygraphic();
    }

    public void OnGraphicChanged(int index)
    {
        pilihkualitas = index;
        applygraphic();
    }

    public void applygraphic()
    {
        QualitySettings.SetQualityLevel(pilihkualitas);
        PlayerPrefs.SetInt("QualityLevel", pilihkualitas);
    }
}
