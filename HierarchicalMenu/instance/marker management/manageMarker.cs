manageMarker
	"startUp a deeper menu if the cursor goes out to the right"
	| aPoint |
	aPoint _ Sensor cursorPoint.
	(frame inside containsPoint: aPoint)
		ifTrue: [self markerOn: aPoint.  ^ selections at: selection].
	selection = 0 ifTrue: [^ nil].
	(aPoint x > frame inside right and: [(deeperMenus at: selection) notNil])
		ifTrue: [^ (deeperMenus at: selection) startUp].
	self markerOff.
	^ nil