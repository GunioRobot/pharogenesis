beginsWith: prefix
	"Answer whether the receiver begins with the given prefix string."

	self size < prefix size ifTrue: [^ false].
	^ (self findMultiSubstring: (MultiString from: prefix) in: self startingAt: 1
			matchTable: nil) = 1
