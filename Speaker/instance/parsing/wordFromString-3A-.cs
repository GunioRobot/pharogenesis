wordFromString: aString
	^ Word new
		string: aString;
		syllables: (self syllabizationOf: (self transcriber transcriptionOf: aString))