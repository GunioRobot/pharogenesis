tempoMap: tempoEventList

	tempoEventList ifNil: [
		tempoMap _ #().
		^ self].
	tempoMap _ tempoEventList asArray.
