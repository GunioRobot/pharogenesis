brass2
	"FMSound brass2 play"
	"(FMSound lowMajorScaleOn: FMSound brass2) play"

	| snd p env |
	snd _ FMSound pitch: 220 dur: 1 loudness: 0.8.
	snd modulation: 0 multiplier: 1.

	p _ OrderedCollection new.
	p add: 0@0.1; add: 30@1.0; add: 40@0.8; add: 100@0.7; add: 160@0.8; add: 200@0.0.
	env _ Envelope points: p loopStart: 3 loopEnd: 5.
	env target: snd; updateSelector: #modulation:; scale: 5.0.
	snd addEnvelope: env.

	p _ OrderedCollection new.
	p add: 0@0.0; add: 20@1.0; add: 40@0.9; add: 100@0.7; add: 160@0.9; add: 200@0.0.
	env _ VolumeEnvelope points: p loopStart: 3 loopEnd: 5.
	env target: snd; scale: 0.2.
	snd addEnvelope: env.

	snd duration: 1.0.
	^ snd
