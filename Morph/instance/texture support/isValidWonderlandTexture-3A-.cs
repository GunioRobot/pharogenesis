isValidWonderlandTexture: aBool
	"Return true if the receiver is a valid wonderland texture"
	aBool == true
		ifTrue:[self removeProperty: #isValidWonderlandTexture]
		ifFalse:[self setProperty: #isValidWonderlandTexture toValue: aBool].