primitiveIsIdentity
	| matrix |
	self export: true.
	self inline: false.
	self var: #matrix declareC:'float *matrix'.
	matrix _ self loadArgumentMatrix: (interpreterProxy stackObjectValue: 0).
	interpreterProxy failed ifTrue:[^nil].
	interpreterProxy pop: 1.
	interpreterProxy pushBool:(
		((matrix at: 0) = (self cCoerce: 1.0 to: 'float')) &
		((matrix at: 1) = (self cCoerce: 0.0 to: 'float')) &
		((matrix at: 2) = (self cCoerce: 0.0 to: 'float')) &
		((matrix at: 3) = (self cCoerce: 0.0 to: 'float')) &
		((matrix at: 4) = (self cCoerce: 1.0 to: 'float')) &
		((matrix at: 5) = (self cCoerce: 0.0 to: 'float'))).