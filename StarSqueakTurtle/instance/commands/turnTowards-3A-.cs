turnTowards: aPointTurtleOrPatch
	"Turn to face the given point, turtle, or patch."

	| degrees |
	degrees := (aPointTurtleOrPatch asPoint - self asPoint) degrees.
	headingRadians := (0.0 - degrees) degreesToRadians.

