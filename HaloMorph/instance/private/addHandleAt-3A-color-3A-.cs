addHandleAt: aPoint color: aColor
	"Add a handle centered at the given point with the given color. Return the handle."
	| handle |
	handle _ EllipseMorph
		newBounds: (Rectangle center: aPoint extent: 16@16)
		color: aColor.
	self addMorph: handle.
	handle on: #mouseUp send: #endInteraction to: self.
	handle setBalloonText: (target balloonHelpTextForHandle: handle).
	^ handle
