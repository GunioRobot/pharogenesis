withBlanksTrimmed
	"Return a copy of the receiver from which leading and trailing blanks have been trimmed."

	| first result |
	first _ self findFirst: [:c | c isSeparator not].
	first = 0 ifTrue: [^ ''].  "no non-separator character"
	result _  self
		copyFrom: first
		to: (self findLast: [:c | c isSeparator not]).
	result isOctetString ifTrue: [^ result asOctetString] ifFalse: [^ result].

	" ' abc  d   ' withBlanksTrimmed"
