renameMe
	| otherNames newName |
	otherNames _ Set newFrom: self pasteUpMorph allKnownNames.
	newName _ FillInTheBlank request: 'Please give this new a name'
						initialAnswer: self knownName.
	newName isEmpty ifTrue: [^ nil].
	(otherNames includes: newName) ifTrue:
			[self inform: 'Sorry, that name is already used'. ^ nil].
	self setNamePropertyTo: newName