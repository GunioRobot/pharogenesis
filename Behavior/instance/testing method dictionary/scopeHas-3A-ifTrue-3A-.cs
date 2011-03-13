scopeHas: name ifTrue: assocBlock 
	"If the argument name is a variable known to the receiver, then evaluate 
	the second argument, assocBlock."

	^superclass scopeHas: name ifTrue: assocBlock