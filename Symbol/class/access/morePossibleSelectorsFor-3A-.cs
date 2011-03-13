morePossibleSelectorsFor: misspelled
	"Like possible SelectorsFor, but over hunts over a greater range of selectors."

	| numArgs results tables skip |
	numArgs _ misspelled numArgs.
	numArgs < 0 ifTrue: [ ^ OrderedCollection new: 0 ].
	skip _ misspelled first asciiValue - $a asciiValue + 1.
	tables _ SelectorTables at: (numArgs + 1 min: SelectorTables size).
	1 to: tables size do: [ :index |
		index ~= skip ifTrue:
			[ results _ misspelled correctAgainst: (tables at: index)
								continuedFrom: results ] ].
	^ misspelled correctAgainst: nil continuedFrom: results.
