readVec2f
	^self readFloatVector: 2 do:[:array| B3DVector2 x: (array at: 1) y: (array at: 2)].