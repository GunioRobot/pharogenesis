extent: newExtent
	| w h inner labelRect |
	super extent: newExtent.
	inner _ self innerBounds.
	labelRect _ inner topLeft corner: inner topRight + (0@self labelHeight).

	w _ inner width - 2 // 4.  h _ inner height - labelRect height // 3.
	systemPane bounds: (labelRect bottomLeft + (1@1) extent: w @ h).
	classPane bounds: (systemPane bounds topRight extent: w @ (h - 20)).
	categoryPane bounds: (classPane bounds topRight extent: w @ h).
	messagePane bounds: (categoryPane bounds topRight corner: inner right-2 @ categoryPane bounds bottom).
	instButton bounds: (systemPane bounds bottomRight + (2@-2) rect: classPane bounds bottomCenter + (0@2)).
	classButton bounds: (categoryPane bounds bottomLeft + (-2@-2) rect: classPane bounds bottomCenter + (0@2)).
	codePane bounds: (systemPane bounds bottomLeft corner: inner bottomRight - 1)