properties: aMethodProperties
	"Set the method-properties of the receiver to aMethodProperties."

	aMethodProperties pragmas do: [ :each | each setMethod: self ].
	^ self literalAt: self numLiterals - 1 put: aMethodProperties.