addPoohHandle: handleSpec
	(innerTarget isKindOf: WonderlandCameraMorph) ifTrue:
		[self addHandle: handleSpec on: #mouseDown send: #strokeMode to: innerTarget]
