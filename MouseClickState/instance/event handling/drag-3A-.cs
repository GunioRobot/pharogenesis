drag: event

	dragSelector ifNotNil: [clickClient perform: dragSelector with: event]