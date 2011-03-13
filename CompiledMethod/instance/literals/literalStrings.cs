literalStrings
	| lits litStrs |
	lits _ self literals.
	litStrs _ OrderedCollection new: lits size * 3.
	self literals do:
		[:lit | 
		(lit isMemberOf: Association)
			ifTrue: [litStrs addLast: lit key]
			ifFalse: [(lit isMemberOf: Symbol)
				ifTrue: [litStrs addAll: lit keywords]
				ifFalse: [litStrs addLast: lit printString]]].
	^ litStrs