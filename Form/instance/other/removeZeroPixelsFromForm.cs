removeZeroPixelsFromForm
	"Make all zero-valued pixels in this Form be black, rather than transparent."
	"Warnings: This method modifies the receiver. It may lose some color accuracy on 32-bit Forms, since the transformation uses a color map with only 15-bit resolution."

	self mapColor: Color transparent to: Color black.
