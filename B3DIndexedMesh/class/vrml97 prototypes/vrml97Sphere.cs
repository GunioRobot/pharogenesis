vrml97Sphere
	"Return a mesh representing a VRML97 Sphere"
	^VRMLSphereCache ifNil:[
		VRMLSphereCache _ (B3DSimpleMesh withAll: self vrmlCreateSphereFaces) asIndexedMesh].