readPitchAndDuration
	| tokens code |
	stream next.
	tokens := (stream upTo: $>) findTokens: ','.
	currentDuration := tokens first asNumber / 1000.0.
	tokens size > 1 ifFalse: [^ self].
	code := tokens last asNumber.
	currentPitch := code > "37" 64 ifTrue: [code] ifFalse: [AbstractSound pitchForMIDIKey: 35 + code]