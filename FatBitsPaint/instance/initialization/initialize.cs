initialize

	super initialize.
	formToEdit _ Form extent: 50@40 depth: 8.
	formToEdit fill: formToEdit boundingBox fillColor: Color veryVeryLightGray.
	magnification _ 4.
	color _ Color veryVeryLightGray.
	brushColor _ Color red.
	brushSize _ 3.
	self revert.
