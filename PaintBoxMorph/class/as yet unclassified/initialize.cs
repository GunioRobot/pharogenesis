initialize
	"PaintBoxMorph initialize"

	Prototype eventHandler: nil.
	Prototype focusMorph: nil.
	Prototype stampHolder clear.  "clear stamps"
	Prototype delete.  "break link to world, if any"

	AllOnImage _ AllOffImage _ AllPressedImage _ nil.
	OriginalBounds _ nil.

