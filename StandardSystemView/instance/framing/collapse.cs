collapse
	"If the receiver is not already collapsed, change its view to be that of its 
	label only."

	self isCollapsed ifFalse:
			[model modelSleep.
			(subViews ~~ nil and: [subViews size = 1 and: [subViews first isKindOf: MorphWorldView]])
				ifTrue: [subViews first deEmphasizeView].
			expandedViewport _ self viewport.
			savedSubViews _ subViews.
			self resetSubViews.
			labelText isNil ifTrue: [self label: nil.  bitsValid _ false.].
			self window: (self inverseDisplayTransform:
					((self labelDisplayBox topLeft extent: (labelText extent x + 70) @ self labelHeight)
						 intersect: self labelDisplayBox))]