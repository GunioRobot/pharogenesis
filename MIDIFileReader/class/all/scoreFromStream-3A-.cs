scoreFromStream: aStream

	aStream binary.
	^ (self new readMIDIFrom: aStream) asScore.
