writeFloatVector: aCollection
	1 to: aCollection size do:[:i|
		self writeFloat: (aCollection at: i).
		i < aCollection size ifTrue:[self space].
	].