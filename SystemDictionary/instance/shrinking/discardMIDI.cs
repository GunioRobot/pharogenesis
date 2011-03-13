discardMIDI
	"Discard support the MIDI score player and the underlying MIDI support."

	Smalltalk removeClassNamed: #ScorePlayerMorph.
	SystemOrganization removeCategoriesMatching: 'Music-Scores'.
