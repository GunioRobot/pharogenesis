debugDraw
	Display deferUpdates: false.
	self fullDrawOn: (Display getCanvas).
	Display deferUpdates: false.
	Display forceToScreen: bounds.