updateScorePlayers
	"Force all ScorePlayers to update their instrument list from the sound library. This may done after loading, unloading, or replacing a sound to make all ScorePlayers feel the change."

	ScorePlayer allSubInstances do: [:p | p pause].
	SoundPlayer shutDown.
	ScorePlayerMorph allInstances do: [:p | p updateInstrumentsFromLibrary].
