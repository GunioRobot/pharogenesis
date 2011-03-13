extent: newExtent 
	isCollapsed
		ifTrue: [super extent: newExtent x @ (self labelHeight + 2)]
		ifFalse: [super extent: newExtent].
	self setStripeColorsFrom: self paneColorToUse.
	label fitContents; setWidth: (label width min: bounds width - self labelWidgetAllowance).
	label layoutFrame leftOffset: label width negated // 2.
	isCollapsed
		ifTrue: [collapsedFrame _ self bounds]
		ifFalse: [fullFrame _ self bounds]