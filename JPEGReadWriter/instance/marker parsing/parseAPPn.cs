parseAPPn

	| length buffer thumbnailLength markerStart |
	markerStart _ self position.
	length _ self nextWord.
	buffer _ self next: 4.
	(buffer asString = 'JFIF') ifFalse: [
		"Skip APPs that we're not interested in"
		stream next: length-6.
		^self].
	self next.
	majorVersion _ self next.
	minorVersion _ self next.
	densityUnit _ self next.
	xDensity _ self nextWord.
	yDensity _ self nextWord.
	thumbnailLength _ self next * self next * 3.
	length _ length - (self position - markerStart).
	length = thumbnailLength ifFalse: [self error: 'APP0 thumbnail length is incorrect.'].
	self next: length