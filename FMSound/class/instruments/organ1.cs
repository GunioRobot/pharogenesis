organ1
	"FMSound organ1 play"
	"(FMSound majorScaleOn: FMSound organ1) play"

	| snd p env |
	snd _ FMSound pitch: 220 dur: 1 loudness: 0.8.
	snd modulation: 0 multiplier: 0.

	p _ OrderedCollection new.
	p add: 0@0; add: 60@1.0; add: 125@0.6; add: 200@1.0; add: 250@0.0.
	env _ VolumeEnvelope points: p loopStart: 2 loopEnd: 4.
	env target: snd; scale: 0.2.
	snd addEnvelope: env.

	snd duration: 1.0.
	^ snd
