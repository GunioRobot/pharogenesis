pruneToSingleNote: aNote
	"Fill all my keymaps with the given note."

	| oneNoteMap |
	oneNoteMap _ Array new: 128 withAll: aNote.
	sustainedLoud _ oneNoteMap.
	sustainedSoft _ oneNoteMap.
	staccatoLoud _ oneNoteMap.
	staccatoSoft _ oneNoteMap.
