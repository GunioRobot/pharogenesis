is: oop MemberOf: aString
	"InterpreterProxy new is: 42 MemberOf:'SmallInteger'"
	| theClass |
	self var: #aString declareC:'char *aString'.
	theClass _ Smalltalk at: aString asSymbol ifAbsent:[nil].
	^theClass isNil
		ifTrue:[false]
		ifFalse:[^oop isMemberOf: theClass]