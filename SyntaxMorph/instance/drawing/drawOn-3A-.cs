drawOn: aCanvas

	super drawOn: aCanvas.
	self isBlockNode ifTrue:
		[((owner respondsTo: #isMethodNode) and: [owner isMethodNode])
		ifTrue:
			[aCanvas fillRectangle: (self topLeft + (0@-1) extent: self width@1) color: Color gray]
		ifFalse:
			[aCanvas fillRectangle: (self topLeft + (1@1) extent: 2@(self height-2)) color: Color gray.
			aCanvas fillRectangle: (self topLeft + (1@1) extent: 4@1) color: Color gray.
			aCanvas fillRectangle: (self bottomLeft + (1@-1) extent: 4@1) color: Color gray].
		]