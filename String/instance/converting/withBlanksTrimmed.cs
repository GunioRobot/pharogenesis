withBlanksTrimmed
	"Return a copy of the receiver from which leading and trailing blanks 
	have been trimmed.   Simplified by Gerardo Richarte 11/3/97"

	self size = 0 ifTrue: [ ^self ].
	^ self
		copyFrom: (self findFirst: [:eachChar | eachChar isSeparator not])
		to: (self findLast: [:eachChar | eachChar isSeparator not])

	" ' abc  d   ' withBlanksTrimmed"
