extent: newExtent 
	| modExtent |
	modExtent _ self checkExtent: newExtent.
	super extent: modExtent.
	self buildLabels