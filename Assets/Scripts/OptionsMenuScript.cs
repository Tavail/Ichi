using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void ToggleVolume(string mixerVariableName)
    {
        float volume;
        audioMixer.GetFloat(mixerVariableName, out volume);
        if (volume < 0)
        {
            audioMixer.SetFloat(mixerVariableName, 0);
        }
        else
        {
            audioMixer.SetFloat(mixerVariableName, -80);
        }
    }

}
