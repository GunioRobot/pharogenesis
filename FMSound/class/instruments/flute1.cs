flute1
	"FMSound flute1 play"
	"(FMSound majorScaleOn: FMSound flute1) play"

	| snd p env |
	snd _ FMSound pitch: 220 dur: 1 loudness: 0.8.
	snd modulation: 0 multiplier: 0.

	p _ OrderedCollection new.
	p add: 0@0; add: 20@1.0; add: 100@1.0; add: 120@0.0.
	env _ VolumeEnvelope points: p loopStart: 2 loopEnd: 3.
	env target: snd; scale: 0.1.
	snd addEnvelope: env.

	snd duration: 1.0.
	^ snd
