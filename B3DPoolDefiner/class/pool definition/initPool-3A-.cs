initPool: aDictionary
	"B3DPoolDefiner initPool"
	self defineVBConstants: aDictionary.
	self definePrimitiveVertexIndexes: aDictionary.
	self defineMatrixFlags: aDictionary.
	self defineClipConstants: aDictionary.
	self definePrimitiveTypes: aDictionary.
	self defineMaterialAndLights: aDictionary.