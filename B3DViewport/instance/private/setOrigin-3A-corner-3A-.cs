setOrigin: topLeft corner: bottomRight
	super setOrigin: topLeft corner: bottomRight.
	center _ (self origin + self corner) / 2.0.
	scale _ corner - center + (0.5@-0.5). "Rasterizer offset"