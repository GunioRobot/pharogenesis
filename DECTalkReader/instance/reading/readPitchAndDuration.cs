readPitchAndDuration
	| tokens code |
	stream next.
	tokens _ (stream upTo: $>) findTokens: ','.
	currentDuration _ tokens first asNumber / 1000.0.
	tokens size > 1 ifFalse: [^ self].
	code _ tokens last asNumber.
	currentPitch _ code > "37" 64 ifTrue: [code] ifFalse: [AbstractSound pitchForMIDIKey: 35 + code]