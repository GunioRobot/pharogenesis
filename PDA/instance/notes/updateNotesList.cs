updateNotesList

	notesList _ (allNotes select: [:c | c matchesKey: self categorySelected]) sort.
	self notesListIndex: (notesList indexOf: currentItem).
	self changed: #notesListItems