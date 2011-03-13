turnToward: aPlayer
	"Turn to face the given player, unless our positions coincide."

	|  aCostume myPosition itsPosition |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	aCostume _ self costume.
	aCostume isWorldMorph ifTrue: [^ self].
	(self overlaps: aPlayer) ifFalse:
		[((myPosition _ aCostume referencePosition) = (itsPosition _ aPlayer costume referencePosition))
			ifFalse: "avoid division by zero ;-("
				[self setHeading: (myPosition bearingToPoint: itsPosition)]]
