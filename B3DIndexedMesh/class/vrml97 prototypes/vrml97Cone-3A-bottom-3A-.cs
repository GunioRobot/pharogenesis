vrml97Cone: doSide bottom: doBottom
	"Return a mesh representing a VRML97 Cone"
	| idx |
	idx _ 0.
	doBottom ifTrue:[idx _ idx + 2].
	doSide ifTrue:[idx _ idx + 1].
	VRML97ConeCache == nil ifTrue:[
		VRML97ConeCache _ Array new: 3.
		1 to: 3 do:[:i|
			VRML97ConeCache at: i put:
				(self 
					vrmlCreateCone: (i anyMask: 1) 
					bottom: (i anyMask: 2))]].
	^VRML97ConeCache at: idx