mouseDownInDimissHandle: evt with: dismissHandle
	Preferences soundsEnabled ifTrue: [TrashCanMorph playMouseEnterSound].
	self removeAllHandlesBut: dismissHandle.
	dismissHandle color: Color darkGray.