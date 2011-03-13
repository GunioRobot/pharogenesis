scoreFromFileNamed: fileName

	| f score |
	f _ (FileStream readOnlyFileNamed: fileName) binary.
	score _ (self new readMIDIFrom: f) asScore.
	f close.
	^ score
