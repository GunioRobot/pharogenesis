mouseDown: anEvent 
	(self class showSplitterHandles not
			and: [self bounds containsPoint: anEvent cursorPoint])
		ifTrue: [oldColor _ self color.
			self color: Color black].
	^ super mouseDown: anEvent 