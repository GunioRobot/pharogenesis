turnToward: aPlayer
	"Turn to the direction of the given player."
	| angle aCostume |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	aCostume _ self costume.
	aCostume isWorldMorph ifTrue: [^ self].
	(aCostume bounds intersects: aPlayer costume bounds) ifTrue: [^ self].
	angle _ aCostume referencePosition bearingToPoint: aPlayer costume referencePosition.
	self setHeading: angle.
