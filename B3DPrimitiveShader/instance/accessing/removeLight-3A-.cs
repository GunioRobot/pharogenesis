removeLight: lightIndex
	| pLight |
	super removeLight: lightIndex.
	self flag: #b3dBug. 
	"There should be a better way then doing this."
	primitiveLights _ #().
	lights do:[:light| 
		light ifNotNil:[pLight _ light asPrimitiveLight].
		pLight ifNotNil:[primitiveLights _ primitiveLights copyWith: pLight]].