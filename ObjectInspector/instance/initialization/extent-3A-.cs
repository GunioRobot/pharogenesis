extent: newExtent
	| w h inner labelRect |
	super extent: newExtent.
	inner _ self innerBounds.
	labelRect _ inner topLeft corner: inner topRight + (0@self labelHeight).

	w _ inner width - 2 // 3.  h _ inner height - labelRect height - 2 // 3.
	fieldPane bounds: (labelRect bottomLeft + (1@1) extent: w @ (inner height-labelRect height - 2)).
	valuePane bounds: (fieldPane bounds topRight corner: inner right - 1 @ (labelRect bottom + h)).
	doitPane bounds: (valuePane bounds bottomLeft corner: inner bottomRight - 1)