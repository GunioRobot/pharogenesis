renderOn: aRenderer
	self hasVertexColors ifTrue:[
		aRenderer trackAmbientColor: true.
		aRenderer trackDiffuseColor: true].
	^aRenderer drawIndexedTriangleMesh: self