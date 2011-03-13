possibleSelectorsFor: misspelled
	"Answer an ordered collection of possible corrections for the misspelled selector in order of likelyhood."

	| numArgs table lookupString |
	lookupString _ misspelled asLowercase. "correct uppercase selectors to lowercase"
	numArgs _ lookupString numArgs.
	numArgs < 0 ifTrue: [ ^ OrderedCollection new: 0 ].
	table _ (SelectorTables at: (numArgs + 1 min: SelectorTables size))
				at: (lookupString at: 1) asciiValue - "($a asciiValue - 1)" 96.
	^ lookupString correctAgainst: table.