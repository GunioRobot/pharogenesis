drawErrorOn: aCanvas
	"The morph (or one of its submorphs) had an error in its drawing method."
	aCanvas
		frameAndFillRectangle: bounds
		fillColor: Color red
		borderWidth: 1
		borderColor: Color yellow.
	aCanvas line: bounds topLeft to: bounds bottomRight width: 1 color: Color yellow.
	aCanvas line: bounds topRight to: bounds bottomLeft width: 1 color: Color yellow.