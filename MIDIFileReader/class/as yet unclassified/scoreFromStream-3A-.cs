scoreFromStream: binaryStream

	|  score |
	score _ (self new readMIDIFrom: binaryStream) asScore.
	^ score
