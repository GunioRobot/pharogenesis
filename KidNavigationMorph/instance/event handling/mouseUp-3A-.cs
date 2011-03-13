mouseUp: evt

	mouseInside _ (mouseInside ifNil: [false]) not.
	self positionVertically
	