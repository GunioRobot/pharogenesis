createMixer
	"Create a mixed sound consisting of sampled sounds with one sound buffer's worth of samples."

	| snd |
	mixer _ MixedSound new.
	snd _ SampledSound
		samples: (SoundBuffer newMonoSampleCount: 2)  "buffer size will be adjusted dynamically"
		samplingRate: streamSamplingRate.
	mixer add: snd pan: 0.5 volume: volume.
