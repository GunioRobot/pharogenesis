+ aPlayer
	"Treating Players like vectors, add aPlayer to me and return a new Player"

	| new |
	new _ costume usableSiblingInstance player.
	new setX: self getX + aPlayer asPoint x.
	new setY: self getY + aPlayer asPoint y.
	^ new