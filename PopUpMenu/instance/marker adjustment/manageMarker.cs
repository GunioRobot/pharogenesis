manageMarker
	"If the cursor is inside the receiver's frame, then highlight the marked 
	item. Otherwise no item is to be marked."
	| pt |
	pt _ Sensor cursorPoint.
	(frame inside containsPoint: pt)
		ifTrue: [(Display boundingBox containsPoint: pt)
					ifFalse: [pt _ pt - (self scrollIntoView: pt)].
				self markerOn: pt]
		ifFalse: [self markerOff]