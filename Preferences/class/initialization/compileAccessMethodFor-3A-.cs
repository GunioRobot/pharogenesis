compileAccessMethodFor: prefSymbol
	self class compileProgrammatically: (prefSymbol, '
	^ self valueOfFlag: #', prefSymbol) classified: 'standard preferences'