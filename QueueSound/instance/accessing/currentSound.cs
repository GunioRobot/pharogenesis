currentSound
	currentSound isNil ifTrue: [currentSound _ self nextSound].
	^ currentSound