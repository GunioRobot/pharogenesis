extent: newExtent
	| inner |
	super extent: newExtent.
	inner _ self innerBounds.
	closeBox position: (inner topLeft + 2).
	collapseBox position: (inner topRight - (collapseBox width@0) + (-2@2)).
	label bounds: (label bounds align: label bounds topCenter with: inner topCenter).