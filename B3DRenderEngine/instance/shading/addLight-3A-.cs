addLight: aLightSource
	"Add the given light source to the engine.
	Return a handle that can be used to modify the light source later on"
	^shader addLight: (aLightSource transformedBy: transformer)