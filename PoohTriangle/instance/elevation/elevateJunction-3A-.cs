elevateJunction: nSteps
	| height faces |
	self isJunction ifFalse:[^#()].
	height _ self elevationHeight.
	faces _ WriteStream on: #().
	faces nextPutAll: (self elevateJunctionEdge: e1 height: height steps: nSteps).
	faces nextPutAll: (self elevateJunctionEdge: e2 height: height steps: nSteps).
	faces nextPutAll: (self elevateJunctionEdge: e3 height: height steps: nSteps).
	^faces contents