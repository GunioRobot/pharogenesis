extent: extentPoint
	bounds extent = extentPoint ifFalse: [
		cachedImage _ nil.
		self changed.
		bounds _ bounds topLeft extent: extentPoint.
		self layoutChanged.
		self changed].
