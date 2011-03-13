collapse
	"If the receiver is not already collapsed, change its view to be that of its 
	label only."

	self isCollapsed
		ifFalse:
			[expandedViewport _ self viewport.
			savedSubViews _ subViews.
			self resetSubViews.
			labelText isNil ifTrue: [self label: 'No Label'.  bitsValid _ false.].
			self window: (self inverseDisplayTransform: 
				(0@0 extent: labelText extent x + 70 @ 19)).
				"Why is the above necessary???  What does it do?".
			labelFrame borderWidthLeft: 2 right: 2 top: 2 bottom: 2]