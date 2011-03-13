selectedMessageName

	currentSelector ifNil: [^ nil].
	^ currentSelector asSymbol