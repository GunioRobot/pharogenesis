setPatchColorAtX: x y: y to: aColor
	"Paint the patch at the given location with the given color."

	patchColorSetter
		fillColor: aColor;
		destX: (pixelsPerPatch * x truncated);
		destY: (pixelsPerPatch * y truncated);
		copyBits.
