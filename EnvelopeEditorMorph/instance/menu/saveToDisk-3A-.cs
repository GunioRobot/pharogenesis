saveToDisk: evt
	| newName f |
	newName _ FillInTheBlank request: 'Please confirm name for save...'
						initialAnswer: soundName.
	newName isEmpty ifTrue: [^ self].
	f _ FileStream newFileNamed: newName , '.fmp'.
	sound storeOn: f.
	f close