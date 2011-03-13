extent: newExtent
	newExtent = bounds extent ifTrue: [^ self].
	super extent: (newExtent x max: self sliderThickness * 2)
					@ (newExtent y max: self sliderThickness * 2).
	self removeAllMorphs; initializeSlider