is: oop KindOf: aString
	"InterpreterProxy new is: 42 KindOf: 'Number'"
	| theClass |
	self var: #aString declareC:'char *aString'.
	theClass _ Smalltalk at: aString asSymbol ifAbsent:[nil].
	^theClass isNil
		ifTrue:[false]
		ifFalse:[^oop isKindOf: theClass]