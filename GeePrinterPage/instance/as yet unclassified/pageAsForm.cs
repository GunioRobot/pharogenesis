pageAsForm

	| f canvas |
	f _ Form extent: bounds extent depth: 16.
	canvas _ f getCanvas.
	canvas fillColor: pasteUp color.
	canvas translateTo: bounds origin negated clippingTo: f boundingBox during: [ :c |
		pasteUp fullDrawForPrintingOn: c
	].
	^f

