vertexPositionsDo: aBlock
	1 to: self size do:[:i|
		(self at: i) vertexPositionsDo: aBlock.
	]