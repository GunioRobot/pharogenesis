significandAsInteger

	| exp sig |
	exp _ self exponent.
	sig _ (((self at: 1) bitAnd: 16r000FFFFF) bitShift: 32) bitOr: (self at: 2).
	exp > -1023
		ifTrue: [sig _ sig bitOr: (1 bitShift: 52)].
	^ sig.