displayOn: aDisplayMedium transformation: aTransformation clippingBox: clipRect rule: anInteger fillColor: aForm 
	"Display the graphic symbol on the Display according to the arguments 
	of this message."

	graphicSymbol
		displayOn: aDisplayMedium
		transformation: (aTransformation compose: transformation)
		clippingBox: clipRect
		rule: anInteger
		fillColor: aForm