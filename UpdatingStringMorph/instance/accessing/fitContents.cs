fitContents

	| scanner newExtent |
	scanner _ DisplayScanner quickPrintOn: Display box: Display boundingBox font: self fontToUse.
	newExtent _ (((scanner stringWidth: contents) max: self minimumWidth) min: self maximumWidth)  @ scanner lineHeight.
	(self extent = newExtent) ifFalse:
		[self extent: newExtent.
		self changed.
		(owner isKindOf: TileMorph) ifTrue: [owner resizeToFitLabel]]
