allSampleSets: sortedNotes

	| keyMap |
	keyMap _ self midiKeyMapFor: sortedNotes.
	sustainedSoft _ keyMap.
	sustainedLoud _ keyMap.
	staccatoSoft _ keyMap.
	staccatoLoud _ keyMap.
