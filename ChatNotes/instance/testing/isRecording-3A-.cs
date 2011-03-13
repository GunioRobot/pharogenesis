isRecording: aBoolean
	
	isRecording = aBoolean ifTrue: [^self].
	isRecording _ aBoolean.
	self changed: #isRecording	