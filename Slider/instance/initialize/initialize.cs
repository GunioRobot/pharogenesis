initialize
	super initialize.
	bounds := 0@0 corner: 16@100.
	color := Color gray.
	borderWidth := 2.
	borderColor := #inset.
	value _ 0.0.
	self initializeSlider