drawOn: aCanvas

	| c |
	cachedForm = nil ifTrue:  [
		c _ FormCanvas extent: bounds extent.
		self drawDataOn: (c copyOffset: bounds origin negated).
		cachedForm _ c form].
	aCanvas image: cachedForm at: bounds origin.
	self drawPointerOn: aCanvas.
