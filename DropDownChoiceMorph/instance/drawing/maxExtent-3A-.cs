maxExtent: listOfStrings

	| scanner h w maxW |
	maxW _ 0.
	listOfStrings do: [:str |
		scanner _ DisplayScanner quickPrintOn: Display box: Display boundingBox font: self fontToUse.
		w _ (scanner stringWidth: str).
		h _ scanner lineHeight.
		maxW _ maxW max: w].
	self extent: (maxW + 4 + h) @ (h + 4).
	self changed