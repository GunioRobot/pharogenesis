translatedMethodBias: tMeth
	| bias |
	self assertIsTranslatedMethod: tMeth.
	bias _ self fetchWord: MethodBiasIndex ofObject: tMeth.
	self assertIsIntegerObject: bias.
	^self integerValueOf: bias