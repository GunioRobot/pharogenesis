/ aNumber
	"Treating Players like vectors, return a new Player that is myself divided by the number"

	| new |
	new _ costume usableSiblingInstance player.
	new setX: self getX / aNumber asPoint x.
	new setY: self getY / aNumber asPoint y.
	^ new
