animateMaximize
	"Animate maximizing from restored."
	
	|expandedRect restoredRect rects steps|
	expandedRect := self fullScreenBounds.
	restoredRect := self bounds.
	steps := Preferences windowAnimationSteps.
	rects := (1/steps to: 1 by: 1/steps) collect: [:x |
		restoredRect interpolateTo: expandedRect at: (20 raisedTo: x) - 1 / 19].
	self fastAnimateRectangles: rects