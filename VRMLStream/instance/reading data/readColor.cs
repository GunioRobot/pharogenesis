readColor
	^self readFloatVector: 3 do:[:array|
		B3DColor4 r: (array at: 1) g: (array at: 2) b: (array at: 3) a: 1.0
	].
