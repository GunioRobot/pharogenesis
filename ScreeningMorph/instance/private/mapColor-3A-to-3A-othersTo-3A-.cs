mapColor: aColor to: pickValue othersTo: elseValue
	| screenImage colorMap |
	screenImage _ self screenMorph imageForm.
	colorMap _ screenImage newColorMap atAllPut: elseValue.
	colorMap at: (aColor indexInMap: colorMap) put: pickValue.
	screenForm _ Form extent: screenImage extent.
	screenForm copyBits: screenForm boundingBox
			from: screenImage at: 0@0 colorMap: colorMap.
	self changed.
	self privateBounds: (screenImage offset extent: screenForm extent).
	self changed