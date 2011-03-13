displayTransformation: aTransformation clippingBox: clipRect rule: anInteger fillColor: aForm
	"Display the receiver where aTransformation is provided as an argument, 
	rule is anInteger and mask is aForm. No translation. Information to be 
	displayed must be confined to the area that intersects with clipRect."

	self displayOn: Display transformation: aTransformation clippingBox: clipRect
		rule: anInteger fillColor: aForm