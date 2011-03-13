moveToward: aPlayer
	"Move a standard amount in the direction of the given player.  If the object has an instance variable named 'speed', the speed of the motion will be governed by that value"

	| angle aCostume |
	(aPlayer == nil or: [aPlayer == self]) ifTrue: [^ self].
	((aCostume _ self costume) bounds intersects: aPlayer costume bounds) ifTrue: [^ self].
	angle _ aCostume referencePosition bearingToPoint: aPlayer costume referencePosition.
	self setHeading: angle.
	self forward: self getSpeed