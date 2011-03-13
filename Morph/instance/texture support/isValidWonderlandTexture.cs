isValidWonderlandTexture
	"Return true if the receiver is a valid wonderland texture"
	extension == nil ifTrue:[^false].
	^self valueOfProperty: #isValidWonderlandTexture ifAbsent:[true]