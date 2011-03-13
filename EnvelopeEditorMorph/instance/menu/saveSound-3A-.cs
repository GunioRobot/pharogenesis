saveSound: evt
	| newName |
	newName _ FillInTheBlank request: 'Please confirm name for save...'
						initialAnswer: soundName.
	newName isEmpty ifTrue: [^ self].
	AbstractSound soundNamed: newName put: sound.
	soundName _ newName.