setWithText: aText style: aTextStyle compositionRectangle: compRect clippingRectangle: clipRect 
	"Set text and using supplied parameters. Answer max composition width."

	clippingRectangle _ clipRect copy.
	^self
		compositionRectangle: compRect
		text: aText
		style: aTextStyle
		offset: 0 @ 0