randomWeird2
	"FMSound randomWeird2 play"

	| p snd env |
	p _ 220.0 + 4000 atRandom.
	snd _ FMSound pitch: p dur: 5.0 loudness: 0.5.

	env _ VolumeEnvelope exponentialDecay: 0.96.
	env target: snd; scale: 0.5.
	snd addEnvelope: env.

	env _ Envelope exponentialDecay: 0.98.
	env target: snd; updateSelector: #pitch:; scale: p.
	snd addEnvelope: env.

	snd duration: 5.0.
	^ snd
