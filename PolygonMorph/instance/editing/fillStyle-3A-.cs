fillStyle: newColor

	self isOpen
		ifTrue: [^ self borderColor: newColor  "easy access to line color from halo"]
		ifFalse: [^ super fillStyle: newColor]