readRotation
	^self readFloatVector: 4 do:[:array|
		B3DRotation radiansAngle: (array at: 4) axis: 
			(B3DVector3 x: (array at: 1) y: (array at: 2) z: (array at: 3))
	].