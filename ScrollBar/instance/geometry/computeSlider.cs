computeSlider
	super computeSlider.
	interval ifNotNil: [self expandSlider]