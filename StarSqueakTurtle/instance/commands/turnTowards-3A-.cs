turnTowards: aPointTurtleOrPatch
	"Turn to face the given point, turtle, or patch."

	| degrees |
	degrees _ (aPointTurtleOrPatch asPoint - self asPoint) degrees.
	headingRadians _ (0.0 - degrees) degreesToRadians.
