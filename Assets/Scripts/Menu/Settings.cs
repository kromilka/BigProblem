using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
	bool isFullScreen;
	public AudioMixer am;

	public void FullScreenToggle()
	{
		isFullScreen = !isFullScreen;
		Screen.fullScreen = isFullScreen;
	}

	public void AudioVolume(float sliderValue)
	{
		am.SetFloat("masterVolume", sliderValue);
	}
}
