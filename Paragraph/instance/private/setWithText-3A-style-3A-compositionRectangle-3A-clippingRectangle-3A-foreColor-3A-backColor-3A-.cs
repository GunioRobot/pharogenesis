setWithText: aText style: aTextStyle compositionRectangle: compRect clippingRectangle: clipRect foreColor: cf backColor: cb
	"Set text and using supplied parameters. Answer max composition width."

	clippingRectangle := clipRect copy.
	self foregroundColor: cf backgroundColor: cb.
	^ self
		compositionRectangle: compRect
		text: aText
		style: aTextStyle
		offset: 0 @ 0