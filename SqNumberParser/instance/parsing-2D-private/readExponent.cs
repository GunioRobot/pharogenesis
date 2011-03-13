readExponent
	"read the exponent if any (stored in instVar).
	Answer true if found, answer false if none.
	If exponent letter is not followed by a digit,
	this is not considered as an error.
	Exponent are always read in base 10, though i do not see why..."
	
	| eneg |
	exponent := 0.
	sourceStream atEnd
		ifTrue: [^ false].
	(self exponentLetters includes: sourceStream next)
		ifFalse: [sourceStream skip: -1.
			^ false].
	eneg := sourceStream peekFor: $-.
	exponent := self
				nextUnsignedIntegerBase: 10
				ifFail: [sourceStream
						skip: (eneg
								ifTrue: [-2]
								ifFalse: [-1]).
					^ false].
	eneg
		ifTrue: [exponent := exponent negated].
	^ true