addNote
	| newNote |
	newNote _ PDARecord new key: self categorySelected; description: 'new note'.
	allNotes _ allNotes copyWith: newNote.
	self currentItem: newNote.
	self updateNotesList