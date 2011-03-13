numArgs 
	"Answer either the number of arguments that the receiver would take if considered a selector.  Answer -1 if it couldn't be a selector.  Note that currently this will answer -1 for anything begining with an uppercase letter even though the system will accept such symbols as selectors.  It is intended mostly for the assistance of spelling correction."

	| firstChar numColons excess start ix |
	self size = 0 ifTrue: [^ -1].
	firstChar _ self at: 1.
	(firstChar isLetter or: [firstChar = $:]) ifTrue:
		["Fast reject if any chars are non-alphanumeric"
		(self findSubstring: '~' in: self startingAt: 1 matchTable: Tokenish) > 0 ifTrue: [^ -1].
		"Fast colon count"
		numColons _ 0.  start _ 1.
		[(ix _ self findSubstring: ':' in: self startingAt: start matchTable: CaseSensitiveOrder) > 0]
			whileTrue:
				[numColons _ numColons + 1.
				start _ ix + 1].
		numColons = 0 ifTrue: [^ 0].
		firstChar = $:
			ifTrue: [excess _ 2 "Has an initial keyword, as #:if:then:else:"]
			ifFalse: [excess _ 0].
		self last = $:
			ifTrue: [^ numColons - excess]
			ifFalse: [^ numColons - excess - 1 "Has a final keywords as #nextPut::andCR"]].
	firstChar isSpecial ifTrue:
		[self size = 1 ifTrue: [^ 1].
		2 to: self size do: [:i | (self at: i) isSpecial ifFalse: [^ -1]].
		^ 1].
	^ -1.