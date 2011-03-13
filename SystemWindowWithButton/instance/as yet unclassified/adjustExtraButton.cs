adjustExtraButton
	buttonInTitle ifNil: [^ self].
	buttonInTitle align: buttonInTitle topLeft with:  self innerBounds topRight - (buttonInTitle width + 20 @ -3)