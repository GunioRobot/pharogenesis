isPlaying: aBoolean

	isPlaying = aBoolean ifTrue: [^self].
	isPlaying _ aBoolean.
	self changed: #isPlaying	