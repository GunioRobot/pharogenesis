showColorPalette: evt

	self comeToFront.
	colorMemory align: colorMemory bounds topRight 
			with: colorMemoryThin bounds topRight.
	self addMorphFront: colorMemory.