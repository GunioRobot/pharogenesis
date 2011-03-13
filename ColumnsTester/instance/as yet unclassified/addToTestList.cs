addToTestList
	| entry |
	entry _ self queryForNewEntry.
	entry isNil
		ifTrue: [^ nil].
	1 to: entry size do: [:index |
		(theList at: index) add: (entry at: index)].
	self changed: #listArray