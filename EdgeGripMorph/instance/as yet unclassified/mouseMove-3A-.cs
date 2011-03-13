mouseMove: anEvent
	"Track the mouse for resizing."
	
	target ifNil: [^self].
	Preferences fastDragWindowForMorphic 
		ifTrue: [target doFastWindowReframe: self edgeName] 
		ifFalse: [
			lastMouse at: 1 put: anEvent cursorPoint.
			self targetPoint: lastMouse first - lastMouse last.
			self positionPoint: (lastMouse first - lastMouse second)].