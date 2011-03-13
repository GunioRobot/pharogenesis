removeNote

	allNotes _ allNotes copyWithout: currentItem.
	self currentItem: nil.
	self updateNotesList.
