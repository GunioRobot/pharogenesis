originalColor: colorOrSymbol
	| aColor |
	aColor _ (colorOrSymbol isKindOf: Color)
		ifTrue:
			[colorOrSymbol]
		ifFalse:
			[Color lightGreen].
	originalColor _ aColor.
	originalForm fill: RevertBox fillColor: originalColor