randomWeird1
	"FMSound randomWeird1 play"

	| p snd env pts |
	p _ 220.0 + 2000 atRandom.
	snd _ FMSound pitch: p dur: 5.0 loudness: 0.5.

	env _ VolumeEnvelope exponentialDecay: 0.96.
	env target: snd; scale: 0.5.
	snd addEnvelope: env.

	pts _ Array with: 0@0 with: 100@1.0 with: 250@0.7 with: 400@1.0 with: 500@0.
	env _ Envelope points: pts loopStart: 2 loopEnd: 4.
	env target: snd; updateSelector: #pitch:; scale: p.
	snd addEnvelope: env.

	snd duration: 5.0.
	^ snd
