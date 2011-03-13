select: aNode
	self selection: (children indexOf: (children detect: [:ea | ea = aNode] ifNone: []))