mouseDown: evt

	| v |
	self changed.
	v _ evt cursorPoint - bounds center.
	degrees _ v theta radiansToDegrees.
	magnitude _ (v r asFloat / (bounds width asFloat / 2.0)) min: 1.0.
