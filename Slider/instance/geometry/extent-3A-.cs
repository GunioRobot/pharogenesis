extent: aPoint
	super extent: (aPoint x max: self sliderThickness * 2)
					@ (aPoint y max: self sliderThickness * 2).
	self removeAllMorphs; initializeSlider