removeLight: lightIndex
	"Remove the light with the given index"
	(lightIndex < 1 or:[lightIndex > lights size]) ifTrue:[^nil].
	lights at: lightIndex put: nil. "So we don't change the indexes"