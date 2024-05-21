using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerData.TypeVolume TypeVolume;
    [SerializeField] private Slider _slider;

    public float Volume => _slider.value;

    private void Awake()
    {
        SetVolume(1f);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(UpdateVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(UpdateVolume);
    }

    public void SetVolume(float volume)
    {
        _slider.value = Mathf.Clamp(volume, AudioMixerData.MinLiearValueVolume, AudioMixerData.MaxLiearValueVolume);
    }

    private void UpdateVolume(float volume)
    {
        _audioMixer.SetFloat(TypeVolume.ToString(), AudioMixerData.GetAttenuationLevel(volume));
    }
}
