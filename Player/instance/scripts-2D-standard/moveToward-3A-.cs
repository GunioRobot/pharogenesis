moveToward: aPlayer
	"Move a standard amount in the direction of the given player.  If the object has an instance variable named 'speed', the speed of the motion will be governed by that value"

	self turnToward: aPlayer.
	self forward: self getSpeed