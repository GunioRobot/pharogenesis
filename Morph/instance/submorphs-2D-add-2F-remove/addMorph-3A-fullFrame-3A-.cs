addMorph: aMorph fullFrame: aLayoutFrame

	aMorph layoutFrame: aLayoutFrame.
	aMorph hResizing: #spaceFill; vResizing: #spaceFill.
	self addMorph: aMorph.

