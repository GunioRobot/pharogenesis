pruneToNotesPerOctave: notesPerOctave
	"Prune all my keymaps to the given number of notes per octave."

	sustainedLoud _ self midiKeyMapFor:
		(self pruneNoteList: sustainedLoud notesPerOctave: notesPerOctave).
	sustainedSoft _ self midiKeyMapFor:
		(self pruneNoteList: sustainedSoft notesPerOctave: notesPerOctave).
	staccatoLoud _ self midiKeyMapFor:
		(self pruneNoteList: staccatoLoud notesPerOctave: notesPerOctave).
	staccatoSoft _ self midiKeyMapFor:
		(self pruneNoteList: staccatoSoft notesPerOctave: notesPerOctave).
