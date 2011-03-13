displaySpecialComplemented 
	"Display the receiver complemented using its special highlight form."

	highlightForm
		displayOn: Display
		transformation: self displayTransformation
		clippingBox: self insetDisplayBox
		fixedPoint: label boundingBox center