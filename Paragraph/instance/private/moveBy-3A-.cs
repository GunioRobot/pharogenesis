moveBy: delta
	compositionRectangle := compositionRectangle translateBy: delta.
	clippingRectangle := clippingRectangle translateBy: delta.
