literals
	"Answer an Array of the literals referenced by the receiver."
	| literals numberLiterals |
	literals _ Array new: (numberLiterals _ self numLiterals).
	1 to: numberLiterals do:
		[:index |
		literals at: index put: (self objectAt: index + 1)].
	^literals