trianglesDo: aBlock
	1 to: self size do:[:i|
		(self at: i) trianglesDo: aBlock.
	].