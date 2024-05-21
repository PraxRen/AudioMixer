using UnityEngine;

public static class AudioMixerData
{
    public const float MinLiearValueVolume = 0.0001f;
    public const float MaxLiearValueVolume = 1f;
    private const float MultipleForConvertVolume = 20f;

    public enum TypeVolume
    {
        MasterVolume,
        MusicVolume,
        EffectVolume
    }

    public static float GetAttenuationLevel(float liearValueVolume)
    {
        liearValueVolume = Mathf.Clamp(liearValueVolume, MinLiearValueVolume, MaxLiearValueVolume);
        return Mathf.Log10(liearValueVolume) * MultipleForConvertVolume;
    }
}
