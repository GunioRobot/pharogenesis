notesMenu: aMenu

	aMenu add: 'add new note' target: self selector: #addNote.
	notesListIndex > 0 ifTrue:
		[aMenu add: 'remove note' target: self selector: #removeNote].
	^ aMenu