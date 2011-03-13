numArgs 
	"Answer either the number of arguments that the receiver would take if considered a selector.  Answer -1 if it couldn't be a selector. It is intended mostly for the assistance of spelling correction."

	| firstChar numColons start ix |
	self size = 0 ifTrue: [^ -1].
	firstChar := self at: 1.
	(firstChar isLetter) ifTrue:
		["Fast reject if any chars are non-alphanumeric
		NOTE: fast only for Byte things - Broken for Wide"
		self class isBytes
			ifTrue: [(self findSubstring: '~' in: self startingAt: 1 matchTable: Tokenish) > 0 ifTrue: [^ -1]]
			ifFalse: [2 to: self size do: [:i | (self at: i) tokenish ifFalse: [^ -1]]].
		"Fast colon count"
		numColons := 0.  start := 1.
		[(ix := self indexOf: $: startingAt: start) > 0]
			whileTrue:
				[ix = start ifTrue: [^-1].
				numColons := numColons + 1.
				start := ix + 1].
		numColons = 0 ifTrue: [^ 0].
		self last = $:
			ifTrue: [^ numColons]
			ifFalse: [^ -1]].
	firstChar isSpecial ifTrue:
		[self size = 1 ifTrue: [^ 1].
		2 to: self size do: [:i | (self at: i) isSpecial ifFalse: [^ -1]].
		^ 1].
	^ -1.