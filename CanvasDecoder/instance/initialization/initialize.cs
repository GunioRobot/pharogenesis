initialize
	"set the canvas to draw on"
	drawingCanvas := FormCanvas extent: 100@100 depth: 16.
	clipRect _ drawingCanvas extent.
	transform _ MorphicTransform identity.

	fonts := Array new: 2.