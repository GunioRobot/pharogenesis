display
	"Show a swatch of this color tracking the cursor until the next mouseClick. 6/14/96 tk"
	"Color red display"
	| f c |
	f _ Form extent: 40@20 depth: Display depth.
	c _ Bitmap with: (self pixelWordForDepth: Display depth).
	f fillColor: c.
	Cursor blank showWhile:
		[f follow: [Sensor cursorPoint] while: [Sensor noButtonPressed]]