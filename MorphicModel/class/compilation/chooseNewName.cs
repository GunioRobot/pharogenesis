chooseNewName
	"Rename this class."
	| oldName newName |
	oldName _ self name.
		[newName _ (FillInTheBlank request: 'Please give this Model a name'
					initialAnswer: oldName) asSymbol.
		newName = oldName ifTrue: [^ self].
		Smalltalk includesKey: newName]
		whileTrue:
		[PopUpMenu notify: 'Sorry, that name is already in use.'].
	self rename: newName.