drawOn: aCanvas

	| c |
	cachedForm = nil ifTrue:  [
		c _ Display defaultCanvasClass extent: bounds extent.
		c translateBy: bounds origin negated
			during:[:tempCanvas| self drawDataOn: tempCanvas].
		cachedForm _ c form].
	aCanvas cache: bounds
			using: cachedForm
			during:[:cachingCanvas| self drawDataOn: cachingCanvas].
	self drawCursorOn: aCanvas.
