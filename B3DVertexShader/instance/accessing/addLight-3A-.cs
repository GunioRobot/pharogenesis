addLight: aLightSource
	lights add: aLightSource.
	needsLightUpdate _ true.
	^lights size