fillStyle: aFillStyle
	"Set the current fillStyle of the receiver."
	self setProperty: #fillStyle toValue: aFillStyle.
	"Workaround for Morphs not yet converted"
	backgroundColor _ aFillStyle asColor.
	self changed.