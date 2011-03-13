xDigit
	"Form a number."

	tokenType _ #number.
	(aheadChar = 30 asCharacter and: [source atEnd
			and:  [source skip: -1. source next ~= 30 asCharacter]])
		ifTrue: [source skip: -1 "Read off the end last time"]
		ifFalse: [source skip: -2].
	token _ [Number readFrom: source] ifError: [:err :rcvr | self offEnd: err].
	self step; step