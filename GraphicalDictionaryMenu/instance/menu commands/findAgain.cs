findAgain
	"Look for the next occurrence of the search string"

	| toFind searchIndex |
	lastSearchString ifNil: [lastSearchString _ 'controls'].
	searchIndex _ currentIndex + 1.
	searchIndex > entryNames size ifTrue:
		[currentIndex _ 0.
		self inform: 'not found' translated.
		^ self].
	toFind _ '*', lastSearchString, '*'.
	[toFind match: (entryNames at: searchIndex) asString]
		whileFalse:
			[searchIndex _ (searchIndex \\ entryNames size) + 1.
			searchIndex == currentIndex ifTrue:
				[^ (toFind match: (entryNames at: searchIndex) asString)
					ifFalse:
						[self inform: 'not found' translated]
					ifTrue:
						[self flash]]].

	currentIndex _ searchIndex.
	self updateThumbnail