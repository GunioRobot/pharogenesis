findEntry
	| toFind searchIndex |
	toFind _ FillInTheBlank request: 'Type name or fragment: ' initialAnswer: 'Controls'.
	toFind isEmptyOrNil ifTrue: [^ self].
	searchIndex _ currentIndex + 1.
	toFind _ '*', toFind asLowercase, '*'.
	[toFind match: (entryNames at: searchIndex) asString]
		whileFalse:
			[searchIndex _ (searchIndex \\ entryNames size) + 1.
			searchIndex == currentIndex ifTrue: [^ self inform: 'not found']].

	currentIndex _ searchIndex.
	self updateThumbnail