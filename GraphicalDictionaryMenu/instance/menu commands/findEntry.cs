findEntry
	"Prompt the user for a search string and find the next match for it"

	| toFind searchIndex |
	lastSearchString ifNil: [lastSearchString _ 'controls'].
	toFind _ FillInTheBlank request: 'Type name or fragment: ' initialAnswer: lastSearchString.
	toFind isEmptyOrNil ifTrue: [^ self].
	lastSearchString _ toFind asLowercase.
	searchIndex _ currentIndex + 1.
	toFind _ '*', lastSearchString, '*'.
	[toFind match: (entryNames at: searchIndex) asString]
		whileFalse:
			[searchIndex _ (searchIndex \\ entryNames size) + 1.
			searchIndex == currentIndex ifTrue: [^ self inform: 'not found']].

	currentIndex _ searchIndex.
	self updateThumbnail