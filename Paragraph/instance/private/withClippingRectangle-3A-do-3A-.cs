withClippingRectangle: clipRect do: aBlock
	| saveClip |
	saveClip _ clippingRectangle.
	clippingRectangle _ clipRect.
		aBlock value.
	clippingRectangle _ saveClip