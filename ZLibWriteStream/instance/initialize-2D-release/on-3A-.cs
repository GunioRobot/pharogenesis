on: aCollection
	super on: aCollection.
	encoder nextBits: 8 put: 120. "deflate method with 15bit window size"
	encoder nextBits: 8 put: 1. "check sum; no preset dictionary"
