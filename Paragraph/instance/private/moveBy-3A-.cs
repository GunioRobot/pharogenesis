moveBy: delta
	compositionRectangle _ compositionRectangle translateBy: delta.
	clippingRectangle _ clippingRectangle translateBy: delta.
