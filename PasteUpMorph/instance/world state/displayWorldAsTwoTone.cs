displayWorldAsTwoTone
	"Display the world in living black-and-white. (This is typically done to save space.)"

	| f |
	f _ ColorForm extent: self viewBox extent depth: 1.
	f colors: (Array with: color dominantColor with: Color black).
	self canvas: (f getCanvas).

	"force the entire canvas to be redrawn"
	self fullRepaintNeeded.
	self drawInvalidAreasOn: self canvas.  "redraw on offscreen canvas"
	self canvas showAt: self viewBox origin.  "copy redrawn areas to Display"
	Display forceDisplayUpdate.
	self canvas: nil.  "forget my canvas to save space"
