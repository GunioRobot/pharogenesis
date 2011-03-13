wonderlandTexture: aTexture
	"Return the current wonderland texture associated with the receiver"
	aTexture == nil
		ifTrue:[self removeProperty: #wonderlandTexture]
		ifFalse:[self setProperty: #wonderlandTexture toValue: aTexture].