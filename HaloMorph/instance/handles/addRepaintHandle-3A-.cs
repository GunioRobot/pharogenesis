addRepaintHandle: haloSpec
	(innerTarget isKindOf: SketchMorph) ifTrue:
		[self addHandle: haloSpec
				on: #mouseDown send: #editDrawing to: innerTarget]
