oboe1
	"FMSound oboe1 play"
	"(FMSound majorScaleOn: FMSound oboe1) play"

	| snd p env |
	snd _ FMSound pitch: 220 dur: 1 loudness: 0.8.
	snd modulation: 1 multiplier: 1.

	p _ OrderedCollection new.
	p add: 0@0; add: 10@1.0; add: 100@1.0; add: 120@0.0.
	env _ VolumeEnvelope points: p loopStart: 2 loopEnd: 3.
	env target: snd; scale: 0.2.
	snd addEnvelope: env.

	snd duration: 1.0.
	^ snd
