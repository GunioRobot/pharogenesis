handlesMouseDown: evt 
	| morph movable |
	morph _ self somethingAt: evt position.
	movable _ morph notNil
				and: [morph isMovable].
	movable
		ifFalse: [self select: nil].
^ movable