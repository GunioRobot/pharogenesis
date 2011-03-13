initialize
	"PaintBoxMorph initialize"

	Prototype ifNotNil: [
		Prototype eventHandler: nil.
		Prototype focusMorph: nil.
		Prototype stampHolder clear.  "clear stamps"
		Prototype delete.  "break link to world, if any"
	].
	AllOnImage := AllOffImage := AllPressedImage := nil.
	OriginalBounds := nil.

