erasePixelsOfColor: evt
	"Let the user specifiy a color such that all pixels of that color should be erased; then do the erasure"

	| c r |
	self changeColorTarget: self selector: #rememberedColor: originalColor: nil hand: evt hand.   "color to erase"
	c _ self rememberedColor ifNil: [Color red].
	originalForm mapColor: c to: Color transparent.
	r _ originalForm rectangleEnclosingPixelsNotOfColor: Color transparent.
	self form: (originalForm copy: r).

