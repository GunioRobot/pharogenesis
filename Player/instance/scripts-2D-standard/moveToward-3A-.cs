moveToward: aPlayer
	"Move a standard amount in the direction of the given player.  If the object has an instance variable named 'speed', the speed of the motion will be governed by that value"

	| myPosition itsPosition |
	((aPlayer ~~ self) and: [(self overlaps: aPlayer) not]) ifTrue:
		[((myPosition _ self costume referencePosition) = (itsPosition _ aPlayer costume referencePosition))
			ifFalse:
				[self setHeading: (myPosition bearingToPoint: itsPosition).
				self forward: self getSpeed]]