initialize
	super initialize.
	bounds := 0@0 corner: 16@100.
	color := Color gray.
	borderWidth := 1.
	borderColor := #inset.
	value _ 0.0.
	descending _ false.
	self initializeSlider