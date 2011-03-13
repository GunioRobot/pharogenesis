changeValueAt: location put: anInteger
	"The receiver's model is a form which has an array of bits. Change the 
	bit at index, location, to be anInteger (either 1 or 0). Inform all objects 
	that depend on the model that it has changed."

	model pixelValueAt: location put: anInteger.
	model changed: self