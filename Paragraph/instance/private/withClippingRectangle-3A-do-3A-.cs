withClippingRectangle: clipRect do: aBlock
	| saveClip |
	saveClip := clippingRectangle.
	clippingRectangle := clipRect.
		aBlock value.
	clippingRectangle := saveClip