isSelfPseudoVariable
	"Answer if this ParseNode represents the 'self' pseudo-variable."

	^ (self key = 'self') | (self name = '{{self}}')