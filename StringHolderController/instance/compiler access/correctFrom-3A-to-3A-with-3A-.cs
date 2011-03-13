correctFrom: start to: stop with: aString
	"Make a correction in the model that the user has authorised from somewhere else in the system (such as from the compilier).  The user's selection is not changed, only corrected."
	| wasShowing userSelection delta loc |
	aString = '#insert period' ifTrue:
		[loc _ start.
		[(loc _ loc-1)>0 and: [(paragraph text string at: loc) isSeparator]]
			whileTrue: [loc _ loc-1].
		^ self correctFrom: loc+1 to: loc with: '.'].
	(wasShowing _ selectionShowing) ifTrue: [ self reverseSelection ].
	userSelection _ self selectionInterval.

	self selectInvisiblyFrom: start to: stop.
	self replaceSelectionWith: aString asText.

	delta _ aString size - (stop - start + 1).
	self selectInvisiblyFrom:
		userSelection first + (userSelection first > start ifFalse: [ 0 ] ifTrue: [ delta ])
		to: userSelection last + (userSelection last > start ifFalse: [ 0 ] ifTrue: [ delta ]).
	wasShowing ifTrue: [ self reverseSelection ].
