openness: aNumber
	| previousCenter |
	previousCenter := self center.
	self extent: self extent x @ (self extent x * 37.0 / 30.0 * aNumber) rounded.
	self align: self center with: previousCenter.
	(self containsPoint: self iris center) ifFalse: [self lookAtFront]