testCloseCauseFlushing
	|transcriptStr|
	transcriptStr := TranscriptStream new.
	transcriptStr cr; space; tab; nextPut: $A; nextPutAll: 'B'.
	self assert: transcriptStr size = 5.
	transcriptStr close.
	self assert: transcriptStr position = 0