skipMarker

	| length markerStart |
	markerStart _ self position.
	length _ self nextWord.
	self next: length - (self position - markerStart)
