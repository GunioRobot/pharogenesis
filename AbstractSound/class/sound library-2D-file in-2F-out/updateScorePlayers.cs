updateScorePlayers
	| soundsBeingEdited |
	"Force all ScorePlayers to update their instrument list from the sound library. This may done after loading, unloading, or replacing a sound to make all ScorePlayers feel the change."

	ScorePlayer allSubInstancesDo:
		[:p | p pause].
	SoundPlayer shutDown.
	soundsBeingEdited _ EnvelopeEditorMorph allSubInstances collect: [:ed | ed soundBeingEdited].
	ScorePlayerMorph allSubInstancesDo:
		[:p | p updateInstrumentsFromLibraryExcept: soundsBeingEdited].
