moveToward: aPlayer

	| angle aCostume |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	((aCostume _ self costume) bounds intersects: aPlayer costume bounds) ifTrue: [^ self].
	angle _ aCostume referencePosition bearingToPoint: aPlayer costume referencePosition.
	self setHeading: angle.
	self forward: self getSpeed