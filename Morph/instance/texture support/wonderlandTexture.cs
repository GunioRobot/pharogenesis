wonderlandTexture
	"Return the current wonderland texture associated with the receiver"
	extension == nil ifTrue:[^nil].
	^self valueOfProperty: #wonderlandTexture ifAbsent:[nil]