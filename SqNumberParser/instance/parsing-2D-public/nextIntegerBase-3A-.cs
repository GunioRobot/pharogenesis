nextIntegerBase: aRadix
	"Form an integer with following digits"
	
	| isNeg value |
	isNeg := sourceStream peekFor: $-.
	value := self nextUnsignedIntegerBase: aRadix.
	^isNeg
		ifTrue: [value negated]
		ifFalse: [value]