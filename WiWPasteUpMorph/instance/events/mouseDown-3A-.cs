mouseDown: evt

	(World == self or: [World isNil]) ifTrue: [^ super mouseDown: evt].
	(self bounds containsPoint: evt cursorPoint) ifFalse: [^ self].

	self becomeTheActiveWorldWith: evt.
