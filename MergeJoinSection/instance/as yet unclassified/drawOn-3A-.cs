drawOn: aCanvas
	"Draw the join on the given canvas."
	
	super drawOn: aCanvas.
	self stateIcon ifNotNilDo: [:i |
		aCanvas
			translucentImage: i
			at: self stateIconBounds topLeft]