copyForShadowDrawingOffset: aPoint

	^ (self copyOrigin: origin + aPoint clipRect: clipRect) setShadowDrawing