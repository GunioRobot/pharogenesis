at: aKey addNote: aNote
	notes isNil ifTrue: [notes _ Dictionary new.].
	notes at: aKey put: aNote.
