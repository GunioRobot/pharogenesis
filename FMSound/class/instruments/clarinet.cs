clarinet
	"FMSound clarinet play"
	"(FMSound lowMajorScaleOn: FMSound clarinet) play"

	| snd p env |
	snd _ FMSound new modulation: 0 ratio: 2.

	p _ OrderedCollection new.
	p add: 0@0.0; add: 60@1.0; add: 310@1.0; add: 350@0.0.
	snd addEnvelope: (VolumeEnvelope points: p loopStart: 2 loopEnd: 3).

	p _ OrderedCollection new.
	p add: 0@0.0167; add: 60@0.106; add: 310@0.106; add: 350@0.0.
	env _ Envelope points: p loopStart: 2 loopEnd: 3.
	env updateSelector: #modulation:; scale: 10.0.
	snd addEnvelope: env.

	^ snd setPitch: 220.0 dur: 1.0 loudness: 0.5
