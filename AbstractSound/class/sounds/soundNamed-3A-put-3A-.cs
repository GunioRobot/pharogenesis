soundNamed: soundName put: aSound

	Sounds at: soundName put: aSound.
	Smalltalk at: #ScorePlayerMorph ifPresent: [:playerClass |
		playerClass allInstancesDo:
			[:player | player updateInstrumentsFromLibrary]].
