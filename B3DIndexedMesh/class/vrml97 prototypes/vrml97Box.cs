vrml97Box
	"Return a mesh representing a VRML97 Box"
	^VRML97BoxCache ifNil:[
		VRML97BoxCache _ (B3DSimpleMesh withAll: self vrmlCreateBoxFaces) asIndexedMesh]