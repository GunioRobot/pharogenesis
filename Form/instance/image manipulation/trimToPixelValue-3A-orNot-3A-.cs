trimToPixelValue: pv orNot: not
	"Return the smallest part of me that includes all pixels of value pv.
	Note:  If orNot is true, then produce a copy that includes all pixels
	that are DIFFERENT from the supplied (background) value"

	^ self copy: (self innerPixelRectFor: pv orNot: not)
"
Try this to select all but the background...
Form fromUser do: [:f |
(f trimToPixelValue: f peripheralColor orNot: true) display]

Or this to select whatever is black...
Form fromUser do: [:f |
(f trimToPixelValue: (Color black pixelValueForDepth: f depth) orNot: false) display]
"