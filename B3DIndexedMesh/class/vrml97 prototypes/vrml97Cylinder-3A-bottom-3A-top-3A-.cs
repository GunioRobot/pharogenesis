vrml97Cylinder: doSide bottom: doBottom top: doTop
	"Return a mesh representing a VRML97 Cylinder"
	| idx |
	idx _ 0.
	doTop ifTrue:[idx _ idx + 4].
	doBottom ifTrue:[idx _ idx + 2].
	doSide ifTrue:[idx _ idx + 1].
	idx = 0 ifTrue:[^nil].
	VRMLCylCache == nil ifTrue:[
		VRMLCylCache _ Array new: 7.
		1 to: 7 do:[:i|
			VRMLCylCache at: i put:
				(self 
					vrmlCreateCylinder: (i anyMask: 1) 
					bottom: (i anyMask: 2) 
					top: (i anyMask: 4))]].
	^VRMLCylCache at: idx