displayWorldAsTwoTone
	"Display the world in living black-and-white. (This is typically done to save space.)"

	| f |
	f _ ColorForm extent: viewBox extent depth: 1.
	f colors: (Array with: color dominantColor with: Color black).
	self canvas: (FormCanvas on: f).

	"force the entire canvas to be redrawn"
	self fullRepaintNeeded.
	self drawInvalidAreasOn: canvas.  "redraw on offscreen canvas"
	canvas showAt: viewBox origin.  "copy redrawn areas to Display"
	Smalltalk forceDisplayUpdate.
	self canvas: nil.  "forget my canvas to save space"
