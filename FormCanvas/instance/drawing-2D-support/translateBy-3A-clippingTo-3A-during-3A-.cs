translateBy: delta clippingTo: aRectangle during: aBlock
	"Set a translation and clipping rectangle only during the execution of aBlock."
	^aBlock value: (self copyOffset: delta clipRect: aRectangle)