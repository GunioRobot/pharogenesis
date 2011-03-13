borderColor: colorOrSymbolOrNil

	borderColor = colorOrSymbolOrNil ifFalse: [
		borderColor _ colorOrSymbolOrNil.
		self changed].
