fitContents

	| newExtent f |
	f _ self fontToUse.
	newExtent _ (((f widthOfString: contents) max: self minimumWidth) min: self maximumWidth)  @ f height.
	(self extent = newExtent) ifFalse:
		[self extent: newExtent.
		self changed]
