extent: newExtent
	| inner panelRect labelRect paneColor |
	self removeHandles.
	isCollapsed
		ifTrue: [super extent: newExtent x @ (self labelHeight + 2)]
		ifFalse: [super extent: newExtent].
	inner _ self innerBounds.
	labelRect _ inner withHeight: self labelHeight.
	panelRect _ self panelRect.
	paneColor _ Color perform: model defaultBackgroundColor.

	stripes first bounds: (labelRect insetBy: 1).
	stripes second bounds: (labelRect insetBy: 3).
	self setStripeColorsFrom: paneColor.
	closeBox align: closeBox topLeft with: inner topLeft + (4@0).
	collapseBox align: collapseBox topRight with: inner topRight - (4@0).
	label fitContents; setWidth: (label width min: bounds width - 50).
	label align: label bounds topCenter with: inner topCenter.
	paneMorphs with: paneRects do:
		[:m :frame |  m color: paneColor.
		m bounds: (((frame scaleBy: panelRect extent) translateBy: panelRect topLeft)) truncated].
	isCollapsed
		ifTrue: [collapsedFrame _ self bounds]
		ifFalse: [fullFrame _ self bounds].
	self isActive ifTrue: [self addHandles]