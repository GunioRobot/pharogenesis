createMixer
	"Create a mixed sound consisting of sampled sounds with one sound buffer's worth of samples. The sound has the same sampling rate and number of channels as the MPEG or MP3 file."

	| channels pan snd |
	mpegFile ifNil: [^ self error: 'No MPEG or MP3 file'].
	channels _ mpegFile audioChannels: mpegStreamIndex.
	streamSamplingRate _ mpegFile audioSampleRate: mpegStreamIndex.
	mixer _ MixedSound new.
	1 to: channels do: [:c |
		channels = 1
			ifTrue: [pan _ 0.5]
			ifFalse: [pan _ (c - 1) asFloat / (channels - 1)].
		snd _ SampledSound
			samples: (SoundBuffer newMonoSampleCount: 2)  "buffer size will be adjusted dynamically"
			samplingRate: streamSamplingRate.
		mixer add: snd pan: pan volume: volume].
