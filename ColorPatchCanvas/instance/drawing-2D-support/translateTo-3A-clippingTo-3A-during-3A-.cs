translateTo: newOrigin clippingTo: aRectangle during: aBlock
	"Set a new origin and clipping rectangle only during the execution of aBlock."
	| tempCanvas |
	tempCanvas _ self copyOrigin: newOrigin clipRect: aRectangle.
	aBlock value: tempCanvas.
	foundMorph _ tempCanvas foundMorph.