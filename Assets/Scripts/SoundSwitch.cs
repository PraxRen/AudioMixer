using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SoundSetting _soundSetting;

    private float _saveValueVolume;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        _saveValueVolume = _soundSetting.Volume;
    }

    private void OnClick()
    {
        if (_soundSetting.Volume <= AudioMixerData.MinLiearValueVolume)
        {
            _soundSetting.SetVolume(_saveValueVolume);
        }
        else
        {
            _saveValueVolume = _soundSetting.Volume;
            _soundSetting.SetVolume(AudioMixerData.MinLiearValueVolume);
        }
    }
}
