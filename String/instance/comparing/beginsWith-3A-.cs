beginsWith: prefix
	"Answer whether the receiver begins with the given prefix string.
	The comparison is case-sensitive."

	self size < prefix size ifTrue: [^ false].
	^ (self findSubstring: prefix in: self startingAt: 1
			matchTable: CaseSensitiveOrder) = 1
