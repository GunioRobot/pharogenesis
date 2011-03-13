getPatchColorAtX: x y: y
	"Answer the color of the patch at the given location."

	| pixel |
	pixel := patchColorGetter pixelAt:
		(pixelsPerPatch * x truncated)@(pixelsPerPatch * y truncated).
	^ Color colorFromPixelValue: pixel depth: patchForm depth
