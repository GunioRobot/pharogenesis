noteNewLocation: location forPlayer: player
	"Note that a morph has just moved with its pen down, begining at startPoint.
	Only used in conjunction with Preferences batchPenTrails."

	lastTurtlePositions ifNil: [lastTurtlePositions _ IdentityDictionary new].
	lastTurtlePositions at: player put: location