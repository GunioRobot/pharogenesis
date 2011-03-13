addHandlesIn: frame
	| handle |
	handle := PolygonMorph
		vertices: (Array with: 0@0 with: 8@0 with: 4@8)
		color: Color orange borderWidth: 1 borderColor: Color black.
	handle addMorph: ((RectangleMorph
			newBounds: ((self handleOffset: handle)-(2@0) extent: 1@(graphArea height-2))
			color: Color orange) borderWidth: 0).

	limitHandles _ Array with: handle with: handle fullCopy with: handle fullCopy.
	1 to: limitHandles size do:
		[:i | handle _ limitHandles at: i.
		handle on: #mouseDown
				send: #limitHandleMoveEvent:from:index:
				to: self withValue: i.
		handle on: #mouseMove
				send: #limitHandleMoveEvent:from:index:
				to: self withValue: i.
		self addMorph: handle.
		handle position: ((self xFromMs: (envelope points at: (limits at: i)) x) @ (graphArea top)) - (self handleOffset: handle)]