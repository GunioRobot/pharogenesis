getIsUnderMouse
	costume isInWorld ifFalse: [^ false].
	^ costume containsPoint: (costume pointFromWorld: costume primaryHand lastEvent cursorPoint)