extent: newExtent 
	| inner labelRect |
	isCollapsed
		ifTrue: [super extent: newExtent x @ (self labelHeight + 2)]
		ifFalse: [super extent: newExtent].
	inner _ self innerBounds.
	labelRect _ self labelRect.
	stripes first bounds: (labelRect insetBy: 1).
	stripes second bounds: (labelRect insetBy: 3).
	self setStripeColorsFrom: self paneColorToUse.
	closeBox ifNotNil: [closeBox align: closeBox topLeft with: inner topLeft + (4 @ 1)].
	menuBox ifNotNil: [menuBox align: menuBox topLeft with: inner topLeft + (19 @ 1)].
	collapseBox align: collapseBox topRight with: inner topRight - (4 @ -1).
	label fitContents; setWidth: (label width min: bounds width - self labelWidgetAllowance).
	label align: label bounds topCenter with: inner topCenter.
	isCollapsed
		ifTrue: [collapsedFrame _ self bounds]
		ifFalse: [self setBoundsOfPaneMorphs. fullFrame _ self bounds]