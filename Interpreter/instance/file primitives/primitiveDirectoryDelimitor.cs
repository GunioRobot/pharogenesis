primitiveDirectoryDelimitor

	| ascii |
	ascii _ self asciiDirectoryDelimiter.
	self success: ((ascii >= 0) and: [ascii <= 255]).
	successFlag ifTrue: [
		self pop: 1.  "pop rcvr"
		self push: (self fetchPointer: ascii ofObject: (self splObj: CharacterTable)).
	].