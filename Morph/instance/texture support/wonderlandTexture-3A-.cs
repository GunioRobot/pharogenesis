wonderlandTexture: aTexture 
	"Return the current wonderland texture associated with the receiver"

	aTexture isNil 
		ifTrue: [self removeProperty: #wonderlandTexture]
		ifFalse: [self setProperty: #wonderlandTexture toValue: aTexture]