mixSampleCount: n into: aByteArray startingAt: startIndex pan: pan
	"Play a number of sounds concurrently. Each sound can be panned independently between the left and right channels."
	"(AbstractSound bachFugueTwoVoices) play"

	| snd sndPan |
	1 to: sounds size do: [ :i |
		(soundDone at: i) ifFalse: [
			snd _ sounds at: i.
			pan = 1000
				ifTrue: [ sndPan _ 1000 ]  "pan argument of 1000 means mono; pass that on"
				ifFalse: [ sndPan _ panSettings at: i ].  "otherwise, use the pan for this voice"
			snd samplesRemaining > 0 ifTrue: [
				snd mixSampleCount: n into: aByteArray startingAt: startIndex pan: sndPan.
			] ifFalse: [
				soundDone at: i put: true.
			].
		].
	].
