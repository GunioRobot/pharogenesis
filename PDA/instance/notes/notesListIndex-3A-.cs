notesListIndex: newValue
	"Assign newValue to notesListIndex."

	notesListIndex = newValue ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	notesListIndex _ newValue.
	self currentItem: (notesListIndex ~= 0
						ifTrue: [notesList at: notesListIndex]
						ifFalse: [nil]).
	self changed: #notesListIndex.