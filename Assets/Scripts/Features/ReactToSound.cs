using UnityEngine;

public class ReactToSound : MonoBehaviour {

	private AudioSource audioSource;
	public float updateStep = 0.01f;
	private int sampleDataLength = 1024;
	
	private float currentUpdateTime = 0f;

	private float clipLoudness;
	private float[] clipSampleData;

	public float sizeFactor = 50f;
	public float minSize = 1f;
	public float maxSize = 1.1f;

	private void Start() {
		clipSampleData = new float[sampleDataLength];
		InstrumentObject inst = GetComponent<InstrumentObject>();
		Sound s = AudioManager.FindSound(inst.instrument.audioName);
		audioSource = s.source;
	}

	private void Update() {
		currentUpdateTime += Time.deltaTime;

		if (audioSource.mute == false) {
			if (currentUpdateTime >= updateStep) {
				currentUpdateTime = 0f;
				audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
				clipLoudness = 0f;

				foreach (var sample in clipSampleData) {
					clipLoudness += Mathf.Abs(sample);
				}

				clipLoudness /= sampleDataLength;
				clipLoudness *= sizeFactor;
				clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
				transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
			}
		}
	}
}
