updateIfOld  "SystemWindow allInstancesDo: [:w | w updateIfOld]"
	| panelRect |
	stripes ifNil:
		[stripes _ Array with: (RectangleMorph newBounds: bounds)
				with: (RectangleMorph newBounds: bounds).
		submorphs _ submorphs , stripes reversed].
	paneMorphs _ submorphs copyFrom: 1 to: submorphs size-5.
	panelRect _ self panelRect.
	paneRects _ paneMorphs collect:
		[:m | (m bounds translateBy: panelRect topLeft negated)
				scaleBy: (1.0/panelRect width)@(1.0/panelRect height)].
	collapseBox actionSelector: #collapseOrExpand.
	fullFrame _ self bounds.
	isCollapsed _ false.
	self extent: self extent.  "Cause layout of stripes etc."