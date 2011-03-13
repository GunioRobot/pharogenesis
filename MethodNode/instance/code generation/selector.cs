selector 
	"Answer the message selector for the method represented by the receiver."

	(selectorOrFalse isMemberOf: Symbol)
		ifTrue: [^selectorOrFalse].
	^selectorOrFalse key