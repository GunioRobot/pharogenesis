adjustExtraButton
	buttonInTitle ifNil: [^ self].
	buttonInTitle align: buttonInTitle topLeft with:  self innerBounds topRight - (buttonInTitle width + 15 @ 1)