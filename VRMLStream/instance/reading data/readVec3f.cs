readVec3f

	^self readFloatVector: 3 do:[:array| 
		B3DVector3 x: (array at: 1) y: (array at: 2) z: (array at: 3)].