moveToward: aPlayer

	| angle |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	(costume bounds intersects: aPlayer costume bounds) ifTrue: [^ self].
	angle _ costume referencePosition bearingToPoint: aPlayer costume referencePosition.
	self setHeading: angle.
	self forward: self getSpeed