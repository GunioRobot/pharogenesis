= aHalfedge

	self species == aHalfedge species ifFalse: [^ false].
	^ (self origin = aHalfedge origin) and: [self opposite origin = aHalfedge opposite origin]