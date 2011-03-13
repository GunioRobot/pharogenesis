displaySelectionBox
	"If the receiver has a selection and that selection is visible on the display 
	screen, then highlight it."
	selection ~= 0 ifTrue:
		[Display reverse: (self selectionBox intersect: self clippingBox)]