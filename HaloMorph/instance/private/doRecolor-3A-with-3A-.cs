doRecolor: evt with: aHandle
	"Change the color of the target, if appropriate"
	evt hand obtainHalo: self.
	(aHandle containsPoint: evt cursorPoint)
		ifFalse:  "only do it if mouse still in handle on mouse up"
			[self delete.
			target addHalo: evt]
		ifTrue:
			[innerTarget changeColor.
			self showingDirectionHandles ifTrue: [self addHandles]]
	
