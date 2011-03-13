nextIntegerBase: aRadix ifFail: aBlock
	"Form an integer with following digits"
	
	| isNeg value |
	isNeg := sourceStream peekFor: $-.
	value := self nextUnsignedIntegerOrNilBase: aRadix.
	value isNil ifTrue: [^aBlock value].
	^isNeg
		ifTrue: [value negated]
		ifFalse: [value]