addLight: aLightSource
	"NOTE: This does not work if primitive/non-primitive lights are mixed!"
	| primLight |
	self flag: #b3dBug. "See above"
	primLight _ aLightSource asPrimitiveLight.
	primLight ifNotNil:[primitiveLights _ primitiveLights copyWith: primLight].
	^super addLight: aLightSource