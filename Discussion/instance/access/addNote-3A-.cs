addNote: aNote
	notes isNil ifTrue: [notes _ OrderedCollection new.].
	notes add: aNote.
	^notes size
