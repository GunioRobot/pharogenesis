bass1
	"FMSound bass1 play"
	"(FMSound lowMajorScaleOn: FMSound bass1) play"

	| snd |
	snd _ FMSound pitch: 220 dur: 1 loudness: 0.8.
	snd modulation: 0 multiplier: 0.
	snd addEnvelope:
		(VolumeEnvelope exponentialDecay: 0.95).
	^ snd setPitch: 220 dur: 1.0 loudness: 0.3
